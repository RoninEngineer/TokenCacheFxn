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
        string SFDCBaseUrl { get; }
        string SFDCGrantType { get; }
        string SFDCClientId { get; }
        string SFDCClientSecret { get; }
        string SFDCUserName { get; }
        string SFDCPassword { get; }

        public bool HasSFDCCredentials { get; }
    }
}
