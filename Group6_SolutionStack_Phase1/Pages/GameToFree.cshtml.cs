using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group6_SolutionStack_Phase1.Pages
{
    public class GameToFreeModel : PageModel
    {
        public Game CurrentGame { get; set; }

        public async Task OnGetAsync()
        {
            await LoadRandomGame();
        }

        public async Task OnPostAsync()
        {
            await LoadRandomGame();
        }

        private async Task LoadRandomGame()
        {
            Random rnd = new Random();

            int randomId = rnd.Next(1, 101);

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://www.freetogame.com/api/")
            };

            var response = await client.GetAsync($"game?id={randomId}");

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();

                CurrentGame = JsonSerializer.Deserialize<Game>(
                    jsonData,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}
