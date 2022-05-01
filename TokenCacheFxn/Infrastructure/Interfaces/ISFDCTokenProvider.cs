using System.Threading.Tasks;

namespace TokenCacheFxn.Infrastructure.Interfaces
{
    public interface ISFDCTokenProvider
    {
        public Task<string> GetToken();
    }
}
