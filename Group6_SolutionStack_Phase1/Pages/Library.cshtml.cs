using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group6_SolutionStack_Phase1.Pages
{
    public class LibraryModel : PageModel
    {
        public List<Game> SavedLibrary { get; set; } = new List<Game>();

        public void OnGet()
        {
            SavedLibrary = SavedGameService.GetSavedGames();
        }

        public IActionResult OnPostDelete(int id)
        {
            SavedGameService.RemoveGame(id);
            return RedirectToPage("/Library");
        }
        public IActionResult OnPostUpdate(int id)
        {
            SavedGameService.FavorateGame(id);
            return RedirectToPage("/Library");
        }
    }
}