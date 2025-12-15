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
            => Ok(_gameService.GetAllGames());

        /// <summary>
        /// Returns a single game by ID.
        /// GET: api/games/{id}
        /// </summary>
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
            => _gameService.GetGameById(id) is { } game
                ? Ok(game)
                : NotFound();

        /// <summary>
        /// Creates a new game.
        /// POST: api/games
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] Game game)
        {
            if (game == null)
                return BadRequest();

            var created = _gameService.AddGame(game);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                created);
        }

        /// <summary>
        /// Updates an existing game.
        /// PUT: api/games/{id}
        /// </summary>
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Game game)
            => _gameService.UpdateGame(id, game)
                ? NoContent()
                : NotFound();

        /// <summary>
        /// Deletes a game by ID.
        /// DELETE: api/games/{id}
        /// </summary>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
            => _gameService.DeleteGame(id)
                ? NoContent()
                : NotFound();
    }
}
