using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HackerNewsAPI.Interface;

namespace HackerNewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IHackerNewsService _hackerNewsService;

        public StoriesController(IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }

        [HttpGet("best/{n}")]
        public async Task<IActionResult> GetBestStories(int n)
        {
            
            var stories = await _hackerNewsService.GetBestStoriesAsync(n);
            return Ok(stories);
        }
    }
}
