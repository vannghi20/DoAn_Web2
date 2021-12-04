using Microsoft.Extensions.Options;
using ProjectWeb2.Common.Config;
using ProjectWeb2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectWeb2.Service
{
    public class ApiService : IApiService
    {
        private readonly GetConnectApi _getApi;
        private IHttpClientFactory _factory;
        public ApiService(IHttpClientFactory factory, IOptions<GetConnectApi> getApi)
        {
            _factory = factory;
            _getApi = getApi.Value;
        }
        public async Task<string> GetApi(string url)
        {
            HttpClient httpClient = _factory.CreateClient();
            httpClient.BaseAddress = new Uri(_getApi.UrlApi);
            var response = await httpClient.GetAsync(url);
            string data = await response.Content.ReadAsStringAsync();

            return data;
        }
    }
}
