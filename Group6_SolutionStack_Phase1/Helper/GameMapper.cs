using Group6_SolutionStack_Phase1.Pages;
using SQLGameDatabase;

namespace Group6_SolutionStack_Phase1.Helpers
{
    public static class GameMapper
    {
        public static SavedGame ConvertToSavedGame(Game game)
        {
            return new SavedGame
            {
                Id = game.id,
                Title = game.title,
                Thumbnail = game.thumbnail,
                Status = game.status,
                ShortDescription = game.short_description,
                Description = game.description,
                GameUrl = game.game_url,
                Genre = game.genre,
                Platform = game.platform,
                Publisher = game.publisher,
                Developer = game.developer,
                FreeToGameProfileUrl = game.freetogame_profile_url,
                IsFavoriteGame = false
            };
        }
    }
}