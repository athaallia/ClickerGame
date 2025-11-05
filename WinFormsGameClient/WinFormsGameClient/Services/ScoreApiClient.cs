using System.Net.Http.Json;
using WinFormsGameClient.Models;

namespace WinFormsGameClient.Services
{
    public class ScoreApiClient
    {
        private readonly HttpClient _http = new HttpClient();
        private readonly string _baseUrl = "http://localhost:5038/api/scores"; // pastikan portnya benar

        public async Task<List<PlayerScore>> GetTopAsync(int top)
        {
            var response = await _http.GetAsync($"{_baseUrl}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<List<PlayerScore>>();
            return data!.OrderByDescending(x => x.Score).Take(top).ToList();
        }

        public async Task SubmitAsync(string name, int score)
        {
            var body = new PlayerScore { PlayerName = name, Score = score };
            var response = await _http.PostAsJsonAsync(_baseUrl, body);
            response.EnsureSuccessStatusCode();
        }
    }
}
