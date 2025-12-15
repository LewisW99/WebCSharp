namespace GameCatalogue.DAL.Entities
{
    /// <summary>
    /// Represents a video game stored in the database.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Primary key (identity).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Game title (e.g. "Half-Life 2").
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Official release date.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Review score (0–100 or 0–10 depending on your choice).
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Primary genre (RPG, FPS, Strategy, etc).
        /// </summary>
        public string Genre { get; set; } = string.Empty;

        /// <summary>
        /// Platform the game released on (PC, PS5, Xbox, etc).
        /// </summary>
        public string Platform { get; set; } = string.Empty;
    }
}
