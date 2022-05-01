using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenCacheFxn.Infrastructure.Interfaces;

namespace TokenCacheFxn.Infrastructure.Providers
{
    public class SFDCTokenProvider : ISFDCTokenProvider
    {
        private readonly IAppSettings _appSettings;
        private readonly IRedisContainer _redisContainer;
        public SFDCTokenProvider(IAppSettings appSettings, IRedisContainer redisContainer)
        {
            _appSettings = appSettings;
            _redisContainer = redisContainer;   
        }

        public async Task<string> GetToken()
        {
            var result = string.Empty;

            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
