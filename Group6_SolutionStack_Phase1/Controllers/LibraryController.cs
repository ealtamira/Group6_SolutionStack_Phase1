using System.Collections.Generic;
using System.Text.Json;
using Group6_SolutionStack_Phase1.Pages;
using Microsoft.AspNetCore.Mvc;
using SQLGameDatabase;

namespace Group6_SolutionStack_Phase1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly GameDAL _dal;
        public LibraryController()
        {
            _dal = new GameDAL();
        }

        [HttpGet]
        public ActionResult<IEnumerable<SavedGame>> GetAll()
        {
            return Ok(_dal.GetSavedGames());
        }

        [HttpGet("{id}")]
        public ActionResult<SavedGame> GetById(int id)
        {
            var game = _dal.GetSavedById(id);
            if (game == null) return NotFound();
            return Ok(game);
        }

        [HttpPost]
        public ActionResult Save([FromBody] SavedGame game)
        {
            //if (rawJson.ValueKind == JsonValueKind.Undefined) return BadRequest();

            //var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            //var game = JsonSerializer.Deserialize<Game>(rawJson.GetRawText(), options);

            if (game == null)
            {
                return BadRequest("Game data was empty or title could not be parsed.");
            }

            _dal.SaveGame(game);
            return Ok(game);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var removed = _dal.RemoveGame(id);
            if (!removed) return NotFound();
            return NoContent();
        }
    }
}