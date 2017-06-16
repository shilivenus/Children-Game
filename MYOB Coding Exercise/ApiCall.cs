using MYOB_Coding_Exercise.Model;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MYOB_Coding_Exercise.Interface;

namespace MYOB_Coding_Exercise
{
    public class ApiCall : IApiCall
    {
        private readonly IHttpClient _httpClient;
        private readonly string _url = ConfigurationManager.AppSettings["url"];

        public ApiCall(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Sends game result as an asynchronous operation.
        /// </summary>
        /// <param name="result">The game result to send</param>
        /// <returns>The bool to tell the post is successed or not</returns>
        public async Task<bool> PostGameResult(GameResult result)
        {
            var stringResult = await Task.Run(() => JsonConvert.SerializeObject(result));

            var httpContent = new StringContent(stringResult, Encoding.UTF8, "application/json");

            try
            {                
                HttpResponseMessage response = await _httpClient.PostAsync(_url + result, httpContent);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Creates a game as an asynchronous operation.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation</returns>
        /// <exception cref="System.Exception">
        /// Exception Thrown when post response is not successful
        /// </exception>
        public async Task<GameManifest> GetGameManifest()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_url);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    GameManifest gameManifest = JsonConvert.DeserializeObject<GameManifest>(result);
                    return gameManifest;
                }
                throw new Exception($"Server error (HTTP {response.StatusCode}).");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
