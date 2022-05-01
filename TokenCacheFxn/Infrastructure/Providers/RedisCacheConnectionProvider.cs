using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenCacheFxn.Infrastructure.Interfaces;

namespace TokenCacheFxn.Infrastructure.Providers

{
    public class RedisCacheConnectionProvider : IRedisCacheContainerProvider
    {
        private readonly IAppSettings _appSettings;
        public RedisCacheConnectionProvider(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        private Lazy<ConnectionMultiplexer> _lazyConnection;
        public IConnectionMultiplexer Connection
        {
            get
            {
                if(_lazyConnection == null)
                {
                    _lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
                    {
                        var option = ConfigurationOptions.Parse(_appSettings.RedisConnection);
                        option.ConnectTimeout = 5000;
                        option.AbortOnConnectFail = false;
                        option.SyncTimeout = 5000;

                        var connection = ConnectionMultiplexer.Connect(option);
                        return connection;

                    });
                }
                return _lazyConnection.Value;
            }
        }
    }
}
