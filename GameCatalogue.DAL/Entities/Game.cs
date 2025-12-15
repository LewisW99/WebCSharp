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
        /// Game title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Official release date.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Review score (0–100).
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Primary genre.
        /// </summary>
        public string Genre { get; set; } = string.Empty;

        /// <summary>
        /// Platform the game released on.
        /// </summary>
        public string Platform { get; set; } = string.Empty;
    }
}
