using System.Net.Http.Json;
using WinFormsGameClient.Models;

namespace WinFormsGameClient.Services
{
    public class ScoreApiClient
    {
        private readonly HttpClient _http;
        private const string BASE_URL = "https://localhost:7173"; // ganti sesuai port API kamu

        public ScoreApiClient()
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri(BASE_URL),
                Timeout = TimeSpan.FromSeconds(10)
            };
        }

        public async Task<List<PlayerScore>> GetTopAsync(int n = 10)
        {
            var res = await _http.GetAsync($"/api/scores/top/{n}");
            res.EnsureSuccessStatusCode();
            var data = await res.Content.ReadFromJsonAsync<List<PlayerScore>>();
            return data ?? new List<PlayerScore>();
        }

        public async Task SubmitAsync(string playerName, int score)
        {
            var payload = new { playerName, score };
            var res = await _http.PostAsJsonAsync("/api/scores", payload);
            res.EnsureSuccessStatusCode();
        }
    }
}
