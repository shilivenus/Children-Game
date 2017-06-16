using System.Net.Http;
using System.Threading.Tasks;

namespace MYOB_Coding_Exercise.Interface
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);

        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}