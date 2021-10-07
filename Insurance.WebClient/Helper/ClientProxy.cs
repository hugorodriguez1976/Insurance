using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.WebClient.Helper
{
    public class ClientProxy
    {
        private string _baseaddress;
        public ClientProxy(string baseAddress)
        {
            _baseaddress = baseAddress;
        }

        public async Task<T> GetRequest<T>(string uri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseaddress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                using (HttpResponseMessage response = await client.GetAsync(uri))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                   return JsonConvert.DeserializeObject<T>(responseBody);
                }
            }
        }

        public async Task<TOut> PostRequest<TIn, TOut>(string uri, TIn content)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseaddress);

                var serialized = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await client.PostAsync(uri, serialized))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<TOut>(responseBody);
                }
            }

        }
    }
}