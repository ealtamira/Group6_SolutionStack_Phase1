using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLGameDatabase;

namespace Group6_SolutionStack_Phase1.Pages
{
    public class LibraryModel : PageModel
    {
        private readonly GameDAL _dal;
        public List<SavedGame> SavedLibrary { get; set; } = new List<SavedGame>();
        public LibraryModel()
        {
            _dal = new GameDAL();
        }
        public void OnGet()
        {
            SavedLibrary = _dal.GetSavedGames();
        }

        public IActionResult OnPostDelete(int id)
        {
            _dal.RemoveGame(id);
            return RedirectToPage("/Library");
        }
        public IActionResult OnPostUpdate(int id)
        {
            _dal.FavoriteGame(id);
            return RedirectToPage("/Library");
        }
    }
}