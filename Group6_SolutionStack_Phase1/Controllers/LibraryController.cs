using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using Group6_SolutionStack_Phase1.Pages;

namespace Group6_SolutionStack_Phase1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetAll()
        {
            return Ok(SavedGameService.GetSavedGames());
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetById(int id)
        {
            var game = SavedGameService.GetSavedById(id);
            if (game == null) return NotFound();
            return Ok(game);
        }

        [HttpPost]
        public ActionResult Save([FromBody] JsonElement rawJson)
        {
            if (rawJson.ValueKind == JsonValueKind.Undefined) return BadRequest();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var game = JsonSerializer.Deserialize<Game>(rawJson.GetRawText(), options);

            if (game == null || string.IsNullOrEmpty(game.title))
            {
                return BadRequest("Game data was empty or title could not be parsed.");
            }

            SavedGameService.SaveGame(game);
            return Ok(game);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var removed = SavedGameService.RemoveGame(id);
            if (!removed) return NotFound();
            return NoContent();
        }
    }
}