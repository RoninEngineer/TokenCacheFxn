using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TokenCacheFxn.Infrastructure.AppSettings;
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
                var cachedToken = await _redisContainer.GetAsync<string>(Constants.WebContext.SFDCAuthorizationCacheKey);
                if(!string.IsNullOrEmpty(cachedToken))
                {
                    result = cachedToken;
                }
                else
                {
                    var _httpClient = new HttpClient();
                    var oAuthSetup = $"grant_type={_appSettings.SFDCGrantType}&"
                        + $"client_id={Uri.EscapeDataString(_appSettings.SFDCClientId)}&"
                        + $"client_secret={Uri.EscapeDataString(_appSettings.SFDCClientSecret)}&"
                        + $"username={Uri.EscapeDataString(_appSettings.SFDCUserName)}&"
                        + $"password={Uri.EscapeDataString(_appSettings.SFDCPassword)}";

                    var stringContent = new StringContent(oAuthSetup, Encoding.UTF8, "application/x-www-form-urlencoded");
                    var response = await _httpClient.PostAsJsonAsync(string.Format("{0}{1}", _appSettings.SFDCBaseUrl, Constants.ServiceUrls.SFDCTokenUrl), stringContent);

                    response.EnsureSuccessStatusCode();
                    var authentication = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                    result = authentication.access_token;

                    await _redisContainer.SetAsync<string>(Constants.WebContext.SFDCAuthorizationCacheKey, result, TimeSpan.FromMinutes(10));

                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
