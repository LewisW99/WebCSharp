using GameCatalogue.DAL.Data;
using GameCatalogue.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameCatalogue.BLL.Services
{
    /// <summary>
    /// Provides business logic layer ( BLL ) 
    ///  bridge between the API and the data layer.
    /// </summary>
    public sealed class GameService
    {
        private readonly GameCatalogueDbContext _context;

        public GameService(GameCatalogueDbContext context)
            => _context = context;

        /// <summary>
        /// Returns all games ordered alphabetically.
        /// </summary>
        public IReadOnlyList<Game> GetAllGames()
            => _context.Games
                       .AsNoTracking()
                       .OrderBy(g => g.Title)
                       .ToList();

        /// <summary>
        /// Returns a single game by ID, or null if not found.
        /// </summary>
        public Game? GetGameById(int id)
            => _context.Games
                       .AsNoTracking()
                       .FirstOrDefault(g => g.Id == id);

        /// <summary>
        /// Adds a new game to the database.
        /// </summary>
        public Game AddGame(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();

            return game;
        }

        /// <summary>
        /// Updates an existing game.
        /// Returns false if the game does not exist.
        /// </summary>
        public bool UpdateGame(int id, Game updatedGame)
        {
            var existing = _context.Games.Find(id);
            if (existing == null)
                return false;

            existing.Title = updatedGame.Title;
            existing.ReleaseDate = updatedGame.ReleaseDate;
            existing.Rating = updatedGame.Rating;
            existing.Genre = updatedGame.Genre;
            existing.Platform = updatedGame.Platform;

            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Deletes a game by ID.
        /// Returns true if deleted, false if not found.
        /// </summary>
        public bool DeleteGame(int id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
                return false;

            _context.Games.Remove(game);
            _context.SaveChanges();
            return true;
        }
    }
}

