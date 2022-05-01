using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TokenCacheFxn.Infrastructure.AppSettings;
using TokenCacheFxn.Infrastructure.Containers;
using TokenCacheFxn.Infrastructure.Interfaces;
using TokenCacheFxn.Infrastructure.Providers;
using TokenCacheFxn.Startup;

[assembly: FunctionsStartup(typeof(TokenCacheFxnStartup))]
namespace TokenCacheFxn.Startup
{
    public  class TokenCacheFxnStartup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();

            builder.Services.AddSingleton<IAppSettings, AppSettings>();
            builder.Services.AddSingleton<IRedisCacheContainerProvider, RedisCacheConnectionProvider>();
            builder.Services.AddSingleton<IRedisContainer, RedisContainer>();
            builder.Services.AddSingleton<ICacheContainer, CacheContainer>() ;
            builder.Services.ConfigureServices(config);
            builder.Services.AddMemoryCache();
            
        }
    }
}
