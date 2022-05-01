using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenCacheFxn.Infrastructure.Interfaces
{
    public interface ICacheContainer
    {
        public T Get<T>(string cacheKey);
        public bool Set<T>(string cacheKey, T value, TimeSpan timeSpan);
    }
}
