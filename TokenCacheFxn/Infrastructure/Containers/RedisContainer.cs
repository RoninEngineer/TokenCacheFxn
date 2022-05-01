using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;
using TokenCacheFxn.Infrastructure.Interfaces;


namespace TokenCacheFxn.Infrastructure.Containers
{
    public class RedisContainer : IRedisContainer, IDisposable
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IRedisCacheContainerProvider _cacheContainerProvider ;
        private bool _disposed = false;

        private bool _connected => _cacheContainerProvider.Connection.IsConnected;
        private IDatabase _cacheDb => _cacheContainerProvider.Connection.GetDatabase();

        public RedisContainer(IRedisCacheContainerProvider cacheContainerProvider, IMemoryCache memoryCache)
        {
            _cacheContainerProvider = cacheContainerProvider;
            _memoryCache = memoryCache; 
        }

        public async Task<T> GetAsync<T>(string cacheKey)
        {
            var result = default(T);

            if(_connected)
            {
                if((_memoryCache != null) && _memoryCache.TryGetValue(cacheKey, out T cachedData))
                {
                    result = cachedData;
                }
                else
                {
                    var cacheValue = await _cacheDb.StringGetAsync(cacheKey);
                    if(cacheValue.HasValue)
                    {
                        result = JsonConvert.DeserializeObject<T>(cacheValue.ToString());
                        _memoryCache?.Set(cacheKey, result, TimeSpan.FromMinutes(1)) ;
                    }
                }
            }
            return result;
        }

        public async Task<bool> SetAsync<T>(string cacheKey, T value, TimeSpan timeSpan)
        {
            var result = false;

            if(value != null && !string.IsNullOrWhiteSpace(cacheKey) && _connected)
            {
                _memoryCache?.Set(cacheKey, value, timeSpan);
                result = true;
                try { result = await _cacheDb.StringSetAsync(cacheKey, JsonConvert.SerializeObject(value), timeSpan); } catch { }
            }
            return result;
        }

        public async Task DeleteAsync(string cacheKey)
        {
            if (string.IsNullOrEmpty(cacheKey) || !_connected) return;
            await _cacheDb.KeyDeleteAsync(cacheKey);
        }

        public async Task<TimeSpan> ValidateRedisConnection()
        {
            return await _cacheDb.PingAsync();
        }

        public void Dispose()
        {
            if(_disposed) return;
            Dispose(true);
            GC.SuppressFinalize(this); ;
        }

        protected virtual void Dispose(bool dispose)
        {
            if(dispose)
            {
                _disposed = true;
                _cacheContainerProvider.Connection.Dispose();
            }
        }
    }
}
