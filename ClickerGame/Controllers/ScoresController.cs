using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ClickerGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoresController : ControllerBase
    {
        private static readonly string filePath = "leaderboard.json";
        private static List<PlayerScore> _scores = LoadScores();

        private static List<PlayerScore> LoadScores()
        {
            if (System.IO.File.Exists(filePath))
            {
                var json = System.IO.File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<PlayerScore>>(json) ?? new();
            }
            return new List<PlayerScore>();
        }

        private static void SaveScores()
        {
            var json = JsonSerializer.Serialize(_scores);
            System.IO.File.WriteAllText(filePath, json);
        }

        [HttpGet("top/{n}")]
        public IActionResult GetTopScores(int n)
        {
            var topScores = _scores
                .OrderByDescending(s => s.Score)
                .Take(n)
                .ToList();
            return Ok(topScores);
        }

        [HttpPost]
        public IActionResult SubmitScore([FromBody] PlayerScore playerScore)
        {
            if (string.IsNullOrEmpty(playerScore.PlayerName))
                return BadRequest("Player name required.");

            _scores.Add(playerScore);
            SaveScores();

            return Ok(new { message = "Score added!" });
        }
    }

    public class PlayerScore
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
    }
}
