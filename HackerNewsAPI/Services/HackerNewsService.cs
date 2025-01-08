using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using HackerNewsAPI.Entities;
using HackerNewsAPI.Interface;

namespace HackerNewsAPI.Services
{
    public class HackerNewsService : IHackerNewsService
    {
        private readonly HttpClient _httpClient;

        public HackerNewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Story>> GetBestStoriesAsync(int n)
        {
            // Obtener los mejores IDs de historias
            var bestStoryIdsUrl = "https://hacker-news.firebaseio.com/v0/beststories.json";
            var storyIds = await _httpClient.GetFromJsonAsync<List<int>>(bestStoryIdsUrl);

            var stories = new List<Story>();

            // Llamar a la API para cada ID (optimizado usando Parallel)
            var tasks = storyIds.Take(n).Select(async id =>
            {
                var storyUrl = $"https://hacker-news.firebaseio.com/v0/item/{id}.json";
                return await _httpClient.GetFromJsonAsync<Story>(storyUrl);
            });

            var results = await Task.WhenAll(tasks);
            stories.AddRange(results.Where(story => story != null).OrderByDescending(s => s.Score));

            return stories;
        }

    }
}
