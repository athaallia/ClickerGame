using ClickerGame.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClickerGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoresController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ScoresController(AppDbContext db)
        {
            _db = db;
        }

        // GET /api/scores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerScore>>> GetAll()
        {
            var scores = await _db.PlayerScores
                .OrderByDescending(s => s.Score)
                .ThenBy(s => s.Id)
                .ToListAsync();

            return Ok(scores);
        }

        // GET /api/scores/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerScore>> GetById(int id)
        {
            var score = await _db.PlayerScores.FindAsync(id);
            if (score == null) return NotFound();
            return Ok(score);
        }

        // POST /api/scores
        [HttpPost]
        public async Task<ActionResult<PlayerScore>> Create(PlayerScore input)
        {
            if (string.IsNullOrWhiteSpace(input.PlayerName))
                return BadRequest("PlayerName wajib diisi");
            if (input.Score < 0)
                return BadRequest("Score tidak boleh negatif");

            // cek apakah nama pemain sudah ada
            var existing = await _db.PlayerScores
                .FirstOrDefaultAsync(s => s.PlayerName == input.PlayerName);

            if (existing != null)
            {
                // kalau skor baru lebih tinggi, update
                if (input.Score > existing.Score)
                {
                    existing.Score = input.Score;
                    existing.CreatedAt = DateTime.UtcNow;
                    await _db.SaveChangesAsync();
                    return Ok(existing); // kirim balik data hasil update
                }
                else
                {
                    // kalau skor baru <= skor lama, tidak diubah
                    return Ok(existing);
                }
            }

            // kalau belum ada, tambahkan data baru
            _db.PlayerScores.Add(input);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = input.Id }, input);
        }

        // PUT /api/scores/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PlayerScore input)
        {
            if (id != input.Id)
                return BadRequest("ID pada URL tidak sesuai dengan body");

            var exists = await _db.PlayerScores.AnyAsync(s => s.Id == id);
            if (!exists) return NotFound();

            _db.Entry(input).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE /api/scores/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var score = await _db.PlayerScores.FindAsync(id);
            if (score == null) return NotFound();

            _db.PlayerScores.Remove(score);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
