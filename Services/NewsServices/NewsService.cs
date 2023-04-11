using DemoBlogForYoutube.Shared;
using DemoBlogForYoutube.Shared.Models;
using System.Net.Http.Json;

namespace DemoBlogForYoutube.Client.Services.NewsServices
{
    public class NewsService : INewsService
    {
        private readonly HttpClient httpClient;
        public NewsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Status> AddOrDeleteNews(News model)
        {
            var result = await httpClient.PostAsJsonAsync("api/news/add", model);
            var response = await result.Content.ReadFromJsonAsync<Status>();
            return response!;
        }

        public async Task<List<News>> Get()
        {
            var result = await httpClient.GetAsync("api/news");
            var response = await result.Content.ReadFromJsonAsync<List<News>>();
            return response!;
        }
    }
}
