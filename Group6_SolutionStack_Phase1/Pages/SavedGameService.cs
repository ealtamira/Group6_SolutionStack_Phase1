using System.Collections.Generic;
using System.Linq;
using Group6_SolutionStack_Phase1.Pages;

namespace Group6_SolutionStack_Phase1
{
    public static class SavedGameService
    {
        private static readonly List<Game> _savedGames = new List<Game>();

        public static List<Game> GetSavedGames()
        {
            return _savedGames;
        }

        public static Game? GetSavedById(int id)
        {
            return _savedGames.FirstOrDefault(g => g.id == id);
        }

        public static void SaveGame(Game game)
        {
            if (!_savedGames.Any(g => g.id == game.id))
            {
                _savedGames.Add(game);
            }
        }

        public static bool RemoveGame(int id)
        {
            var game = GetSavedById(id);
            if (game == null) return false;
            return _savedGames.Remove(game);
        }
    }
}