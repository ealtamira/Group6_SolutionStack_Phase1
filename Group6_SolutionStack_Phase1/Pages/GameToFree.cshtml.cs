using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Group6_SolutionStack_Phase1.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLGameDatabase;

namespace Group6_SolutionStack_Phase1.Pages
{
    public class GameToFreeModel : PageModel
    {
        private readonly GameDAL _dal;

        public GameToFreeModel()
        {
            _dal = new GameDAL();
        }
        [BindProperty]
        public Game? CurrentGame { get; set; }

        public async Task OnGetAsync()
        {
            await LoadRandomGame();
        }

        public async Task OnPostAsync()
        {
            await LoadRandomGame();
        }

        public IActionResult OnPostSave()
        {
            if (CurrentGame == null || string.IsNullOrEmpty(CurrentGame.title))
            {
                return Page();
            }

            try
            {
                //var controller = new Group6_SolutionStack_Phase1.Controllers.LibraryController();
                //string jsonString = JsonSerializer.Serialize(CurrentGame);
                //using (JsonDocument doc = JsonDocument.Parse(jsonString))
                //{
                //    JsonElement rawJson = doc.RootElement.Clone();
                //    var response = controller.Save(rawJson);
                //    if (response is OkObjectResult || response is CreatedAtActionResult)
                //    {
                //        return RedirectToPage("/Library");
                //    }
                //}

                SavedGame savedGame =
                    GameMapper.ConvertToSavedGame(CurrentGame);

                _dal.SaveGame(savedGame);

                return RedirectToPage("/Library");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during API controller save invocation: {ex.Message}");
            }
            return Page();
        }

        private async Task LoadRandomGame()
        {
            Random rnd = new Random();
            int randomId = rnd.Next(1, 101);
            using (HttpClient client = new HttpClient { BaseAddress = new Uri("https://www.freetogame.com/api/") })
            {
                var response = await client.GetAsync($"game?id={randomId}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();

                    var parsedGame = JsonSerializer.Deserialize<Game>(
                        jsonData,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                    if (parsedGame != null)
                    {
                        CurrentGame = parsedGame;
                    }
                }
            }
        }
    }
}