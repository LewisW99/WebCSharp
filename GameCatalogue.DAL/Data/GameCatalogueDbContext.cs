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

            modelBuilder.Entity<Game>()
            .HasIndex(g => g.Title)
            .IsUnique();

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

            modelBuilder.Entity<Game>().HasData(
            new Game
            {
                Id = 1,
                Title = "Half-Life 2",
                ReleaseDate = new DateTime(2004, 11, 16),
                Rating = 96,
                Genre = "FPS",
                Platform = "PC"
            },
            new Game
            {
                Id = 2,
                Title = "The Legend of Zelda: Breath of the Wild",
                ReleaseDate = new DateTime(2017, 3, 3),
                Rating = 97,
                Genre = "Adventure",
                Platform = "Nintendo Switch"
            },
            new Game
            {
                Id = 3,
                Title = "Dark Souls",
                ReleaseDate = new DateTime(2011, 9, 22),
                Rating = 89,
                Genre = "Action RPG",
                Platform = "PC"
            },
            new Game
            {
                Id = 4,
                Title = "Minecraft",
                ReleaseDate = new DateTime(2011, 11, 18),
                Rating = 93,
                Genre = "Sandbox",
                Platform = "Multi-platform"
            }
            );
        }
    }
}
