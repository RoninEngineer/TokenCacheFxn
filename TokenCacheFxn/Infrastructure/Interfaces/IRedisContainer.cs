using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenCacheFxn.Infrastructure.Interfaces
{
    public interface IRedisContainer
    {
        Task<T> GetAsync<T>(string cacheKey);
        Task<bool> SetAsync<T>(string cacheKey, T value, TimeSpan expireTime);
        Task DeleteAsync(string cacheKey);
        Task<TimeSpan> ValidateRedisConnection();
    }
}
