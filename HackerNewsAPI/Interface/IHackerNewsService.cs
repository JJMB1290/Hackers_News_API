using HackerNewsAPI.Entities;

namespace HackerNewsAPI.Interface
{
    public interface IHackerNewsService
    {
        Task<List<Story>> GetBestStoriesAsync(int n);
    }
}
