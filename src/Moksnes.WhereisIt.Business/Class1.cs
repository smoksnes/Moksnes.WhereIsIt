using Moksnes.WhereisIt.Business.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moksnes.WhereisIt.Business
{
    public class TitleSearcher : ITitleSearcher
    {
        private IHttpClient _client;

        public TitleSearcher()
        {
            _client = new HttpClient("http://www.imdb.com");
        }

        public async Task<Rootobject> SearchAsync(string query)
        {
            var request = new RestRequest("xml/find?json=1&nr=1&tt=on&q={query}");
            request.OnBeforeDeserialization = resp => resp.ContentType = "application/json";
            //request.OnBeforeDeserialization = reponse => response.ContentType = "application/json"; ;
            request.RequestFormat = DataFormat.Json;
            request.AddUrlSegment("query", query);
            return await _client.GetAsync<Rootobject>(request);
        }
    }

    public interface IHttpClient
    {
        Task<T> GetAsync<T>(IRestRequest restRequest) where T : class, new();
    }

    public class HttpClient : IHttpClient
    {
        private RestClient _client;

        public HttpClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public Task<T> GetAsync<T>(IRestRequest restRequest) where T : class, new()
        {
            var taskCompletionSource = new TaskCompletionSource<T>();
            _client.ExecuteAsync<T>(restRequest, (response) => {
                taskCompletionSource.SetResult(response.Data);
                });
            return taskCompletionSource.Task;
        }
    }
}
