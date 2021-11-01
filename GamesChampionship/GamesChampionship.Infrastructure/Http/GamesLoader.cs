using GamesChampionship.Domain.Interfaces;
using GamesChampionship.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GamesChampionship.Infrastructure.Http
{
    public class GamesLoader : IGamesLoader
    {
        private readonly HttpClient _httpClient;

        public GamesLoader(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Game>> Load()
        {
            var result = await _httpClient.GetAsync("https://l3-processoseletivo.azurewebsites.net/api/Competidores?copa=games");

            result.EnsureSuccessStatusCode();

            var stringContent = result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<Game>>(stringContent);
        }
    }
}
