using StaticSiteFunctions.Constants.Game;
using System.Text.Json.Serialization;

namespace StaticSiteFunctions.Models
{
    public class Card
    {
        public string image { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
        public string code { get; set; }
        [JsonIgnore]
        public string back { get; set; } = SolitaireImages.BacokOfCard;
    }
}
