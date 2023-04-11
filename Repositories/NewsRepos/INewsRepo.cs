using DemoBlogForYoutube.Shared;
using DemoBlogForYoutube.Shared.Models;

namespace DemoBlogForYoutube.Server.Repositories.NewsRepos
{
    public interface INewsRepo
    {
        Task<Status> AddOrDeleteNews(News model);
        Task<List<News>> Get();
    }
}
