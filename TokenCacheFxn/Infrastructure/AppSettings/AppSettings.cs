using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenCacheFxn.Infrastructure.Interfaces;

namespace TokenCacheFxn.Infrastructure.AppSettings
{
    public class AppSettings : IAppSettings
    {
        public string RedisConnection => Environment.GetEnvironmentVariable(AppSettingsKey.RedisConnectionString);
        public string SFDCBaseUrl => Environment.GetEnvironmentVariable(AppSettingsKey.SFDCBaseURL);
        public string SFDCGrantType => Environment.GetEnvironmentVariable(AppSettingsKey.SFDCGrantType);
        public string SFDCClientId => Environment.GetEnvironmentVariable(AppSettingsKey.SFDCClientId);
        public string SFDCClientSecret => Environment.GetEnvironmentVariable(AppSettingsKey.SFDCClientSecret);
        public string SFDCUserName => Environment.GetEnvironmentVariable(AppSettingsKey.SFDCUserName);
        public string SFDCPassword => Environment.GetEnvironmentVariable(AppSettingsKey.SFDCPassword);

        public bool HasSFDCCredentials =>
            !string.IsNullOrWhiteSpace(SFDCBaseUrl) &&
            !string.IsNullOrWhiteSpace(SFDCGrantType) &&
            !string.IsNullOrWhiteSpace(SFDCClientId) &&
            !string.IsNullOrWhiteSpace(SFDCClientSecret) &&
            !string.IsNullOrWhiteSpace(SFDCUserName) &&
            !string.IsNullOrWhiteSpace(SFDCPassword);

    }
}
