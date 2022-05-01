using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TokenCacheFxn.Infrastructure.AppSettings;
using TokenCacheFxn.Infrastructure.Interfaces;

namespace TokenCacheFxn.Functions
{
    public class SDFCToken
    {
        private readonly ISFDCTokenProvider _sfdcTokenProvider;
        public SDFCToken(ISFDCTokenProvider sFDCTokenProvider)
        {
            _sfdcTokenProvider = sFDCTokenProvider;
        }

        [FunctionName(Constants.FunctionNames.SFDCTokenFunction)]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var authToken = await _sfdcTokenProvider.GetToken();

            return new OkObjectResult(authToken);
        }
    }
}
