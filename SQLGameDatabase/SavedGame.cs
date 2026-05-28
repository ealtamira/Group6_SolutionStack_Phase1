using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGameDatabase
{
    public class SavedGame
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Status { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string GameUrl { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string FreeToGameProfileUrl { get; set; }
        public bool IsFavoriteGame { get; set; } = false;
    }
}
