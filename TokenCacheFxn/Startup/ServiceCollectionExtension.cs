using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TokenCacheFxn.Startup
{
    public static class ServiceCollectionExtension
    {

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetValue<string>("RedisCacheConnectionString");
                options.InstanceName = "SampleInstance";
            });
        }
    }
}
