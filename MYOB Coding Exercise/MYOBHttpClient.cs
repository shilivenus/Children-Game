using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MYOB_Coding_Exercise.Interface;

namespace MYOB_Coding_Exercise
{
    public class MYOBHttpClient: IHttpClient
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return _httpClient.PostAsync(requestUri, content);
        }

        public Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return _httpClient.GetAsync(requestUri);
        }
    }
}
