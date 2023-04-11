using DemoBlogForYoutube.Server.Data;
using DemoBlogForYoutube.Shared;
using DemoBlogForYoutube.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoBlogForYoutube.Server.Repositories.NewsRepos
{
    public class NewsRepo : INewsRepo
    {
        private readonly AppDbContext appDbContext;
        public NewsRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Status> AddOrDeleteNews(News model)
        {
            var status = new Status();
            if(model != null)
            {
                var checkEx = await appDbContext.News
                    .Where(n => n.Title!.ToLower().Replace(" ", "-").Replace("?", "-")
                    .Equals(model.Title!.ToLower().Replace(" ", "-").Replace("?", "-")))
                    .FirstOrDefaultAsync();

                if(checkEx != null)
                {
                    status.Success = false;
                    status.Message = "News already added";
                    return status;
                }

                appDbContext.News.Add(model);
                model.Url = model.Title!.ToLower().Replace(" ", "-").Replace("?", "-");
                await appDbContext.SaveChangesAsync();
                status.Success = true;
                status.Message = "News added successfully";
                return status;
            }
            status.Success = false;
            status.Message = "News object is empty";
            return status;
        }

        public async Task<List<News>> Get()
        {
            var result = await appDbContext.News.ToListAsync();
            return result!;
        }
    }
}
