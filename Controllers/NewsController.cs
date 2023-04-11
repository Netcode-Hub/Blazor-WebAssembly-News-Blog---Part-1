using DemoBlogForYoutube.Server.Repositories.NewsRepos;
using DemoBlogForYoutube.Shared;
using DemoBlogForYoutube.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoBlogForYoutube.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepo newsRepo;
        public NewsController(INewsRepo newsRepo)
        {
            this.newsRepo = newsRepo;
        }

        [HttpPost("add")]
        public async Task<ActionResult<Status>> AddOrDeleteNews(News model)
        {
            if (model == null)
                return BadRequest("News Model is empty");
            return Ok(await newsRepo.AddOrDeleteNews(model));
        }

        [HttpGet]
        public async Task<ActionResult<List<News>>> Get()
        {
            return Ok(await newsRepo.Get());
        }
    }
}
