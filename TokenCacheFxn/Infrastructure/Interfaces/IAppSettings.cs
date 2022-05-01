using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenCacheFxn.Infrastructure.Interfaces
{
    public interface IAppSettings
    {
        string RedisConnection { get; }
    }
}
