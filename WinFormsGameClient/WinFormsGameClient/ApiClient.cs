using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClickerGameClient
{
    public class ApiClient
    {
        private readonly HttpClient _http = new HttpClient();
        private readonly string _baseUrl = "http://localhost:5038/api/Scores";

        public async Task PostScoreAsync(string playerName, int score)
        {
            var data = new
            {
                playerName = playerName,
                score = score
            };

            var json = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(_baseUrl, json);
            response.EnsureSuccessStatusCode();
        }

        public async Task<string> GetScoresAsync()
        {
            var response = await _http.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
