using DemoBlogForYoutube.Shared.Models;
using DemoBlogForYoutube.Shared;

namespace DemoBlogForYoutube.Client.Services.NewsServices
{
    public interface INewsService
    {
        Task<Status> AddOrDeleteNews(News model);
        Task<List<News>> Get();
    }
}
