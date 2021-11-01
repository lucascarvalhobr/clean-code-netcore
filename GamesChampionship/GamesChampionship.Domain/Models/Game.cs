namespace GamesChampionship.Domain.Models
{
    public class Game
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public double Note { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
    }
}
