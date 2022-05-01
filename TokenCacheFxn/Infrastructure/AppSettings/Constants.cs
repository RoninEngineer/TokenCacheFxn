using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenCacheFxn.Infrastructure.AppSettings
{
    public partial class Constants
    {
        public class WebContext
        {
            public const string AuthorizationHeaderName = "Authorization";
            public const string AuthorizationHeaderValue = "Bearer {0}";
            public const string SFDCAuthorizationCacheKey = "SFDCAuthorizationCacheKey";
        }

        public class ServiceUrls
        {
            public const string SFDCTokenUrl = "/services/oauth2/token";
        }

        public class FunctionNames
        {
            public const string SFDCTokenFunction = "SFDCTokenFxn";
        }
    }
}
