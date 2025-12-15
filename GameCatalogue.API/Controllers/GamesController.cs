using GameCatalogue.API.Dtos;
using GameCatalogue.BLL.Services;
using GameCatalogue.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalogue.API.Controllers
{
    /// <summary>
    /// API endpoints for managing the video game db .
    /// delegates all logic to the BLL.
    /// </summary>
    [ApiController]
    [Route("api/games")]
    public sealed class GamesController : ControllerBase
    {
        private readonly GameService _gameService;

        public GamesController(GameService gameService)
            => _gameService = gameService;

        

        /// <summary>
        /// Returns all games.
        /// GET: api/games
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
            => Ok(_gameService.GetAllGames().Select(ToDto));

        /// <summary>
        /// Returns a single game by ID.
        /// GET: api/games/{id}
        /// </summary>
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
             => _gameService.GetGameById(id) is { } game
                ? Ok(ToDto(game))
                : NotFound();

        /// <summary>
        /// Creates a new game.
        /// POST: api/games
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] GameDto dto)
        {
            var game = new Game
            {
                Title = dto.Title,
                ReleaseDate = dto.ReleaseDate,
                Rating = dto.Rating,
                Genre = dto.Genre,
                Platform = dto.Platform
            };

            if (dto.ReleaseDate.Date > DateTime.UtcNow.Date)
                return BadRequest("Release date cannot be in the future.");


            _gameService.AddGame(game);

            return CreatedAtAction(nameof(GetById), new { id = game.Id }, ToDto(game));
        }

        /// <summary>
        /// Updates an existing game.
        /// PUT: api/games/{id}
        /// </summary>
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] GameDto dto)
        {
            var game = new Game
            {
                Title = dto.Title,
                ReleaseDate = dto.ReleaseDate,
                Rating = dto.Rating,
                Genre = dto.Genre,
                Platform = dto.Platform
            };

            if (dto.ReleaseDate.Date > DateTime.UtcNow.Date)
                return BadRequest("Release date cannot be in the future.");


            return _gameService.UpdateGame(id, game)
                ? NoContent()
                : NotFound();
        }

        /// <summary>
        /// Deletes a game by ID.
        /// DELETE: api/games/{id}
        /// </summary>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
            => _gameService.DeleteGame(id)
                ? NoContent()
                : NotFound();

        private static GameDto ToDto(Game game) => new()
        {
            Id = game.Id,
            Title = game.Title,
            ReleaseDate = game.ReleaseDate,
            Rating = game.Rating,
            Genre = game.Genre,
            Platform = game.Platform
        };

       
    }
}
