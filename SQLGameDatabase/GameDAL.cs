using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGameDatabase
{
    public class GameDAL
    {
        private readonly AppDbContext _context;
        public GameDAL()
        {
            _context = new AppDbContext();
        }
        public List<SavedGame> GetSavedGames()
        {
            return _context.Games.ToList();
        }
        public SavedGame GetSavedById(int id)
        {
            return _context.Games.FirstOrDefault(g => g.Id == id);
        }
        public void SaveGame(SavedGame game)
        {
            bool exists = _context.Games.Any(g => g.Id == game.Id);

            if (!exists)
            {
                _context.Games.Add(game);

                _context.SaveChanges();
            }
        }
        public bool RemoveGame(int id)
        {
            var game = GetSavedById(id);

            if (game == null)
            {
                return false;
            }

            _context.Games.Remove(game);

            _context.SaveChanges();

            return true;
        }
        public void FavoriteGame(int id)
        {
            var game = GetSavedById(id);

            if (game != null)
            {
                game.IsFavoriteGame = !game.IsFavoriteGame;

                _context.SaveChanges();
            }
        }
    }
}
