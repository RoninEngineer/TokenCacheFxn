using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenCacheFxn.Infrastructure.Interfaces;

namespace TokenCacheFxn.Infrastructure.Containers
{
    public class CacheContainer : ICacheContainer
    {
        private readonly IMemoryCache _memoryCache;
        public CacheContainer(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache; 

        }

        public T Get<T>(string cacheKey)
        {
            T result = default;

            if((_memoryCache != null) && _memoryCache.TryGetValue(cacheKey, out T cachedData))
            {
                result = cachedData;
            }

            return result;
        }

        public bool Set<T>(string cacheKey, T value, TimeSpan timeSpan)
        {
            var result = false;
            if (value != null && !string.IsNullOrWhiteSpace(cacheKey) && _memoryCache != null)
            {
                _memoryCache.Set(cacheKey, value, timeSpan);
                result = true;
            }

            return result;
        }
    }
}
