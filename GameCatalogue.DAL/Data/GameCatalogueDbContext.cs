using GameCatalogue.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameCatalogue.DAL.Data
{
    /// <summary>
    /// Entity Framework database context for the Game Catalogue.
    /// Responsible only for database access.
    /// </summary>
    public class GameCatalogueDbContext : DbContext
    {
        public GameCatalogueDbContext(DbContextOptions<GameCatalogueDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Video games stored in the database.
        /// </summary>
        public DbSet<Game> Games => Set<Game>();

        /// <summary>
        /// Configure entity mappings and constraints.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Games");

                entity.HasKey(g => g.Id);

                entity.Property(g => g.Title)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(g => g.Genre)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(g => g.Platform)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(g => g.Rating)
                      .HasPrecision(3, 1);
            });
        }
    }
}
