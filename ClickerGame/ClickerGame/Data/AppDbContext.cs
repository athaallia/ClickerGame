using Microsoft.EntityFrameworkCore;

namespace ClickerGame.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PlayerScore> PlayerScores => Set<PlayerScore>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerScore>(entity =>
            {
                entity.Property(p => p.PlayerName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(p => p.Score)
                      .IsRequired();

                entity.Property(p => p.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // seed data awal (static values, aman)
                entity.HasData(
                    new PlayerScore { Id = 1, PlayerName = "Andi", Score = 1200 },
                    new PlayerScore { Id = 2, PlayerName = "Nadia", Score = 980 }
                );
            });
        }
    }

    public class PlayerScore
    {
        public int Id { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public int Score { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
