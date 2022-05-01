using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenCacheFxn.Infrastructure.AppSettings
{
    public class AppSettingsKey
    {
        public const string RedisConnectionString = "RedisCacheConnectionString";
        public const string SFDCBaseURL = "SFDCBaseUrl";
        public const string SFDCGrantType = "SFDCGrantType";
        public const string SFDCClientId = "SFDCClientId";
        public const string SFDCClientSecret = "SFDCClientSecret";
        public const string SFDCUserName = "SFDCUserName";
        public const string SFDCPassword = "SFDCPassword";

    }
}
