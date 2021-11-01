using System.Collections.Generic;

namespace GamesChampionship.Domain.Models
{
    public class Round
    {
        public IEnumerable<Match> Matches { get; private set; }

        public int Position { get; set; }

        public Round(IEnumerable<Match> matches, int position)
        {
            this.Matches = matches;
            this.Position = position;
        }
    }
}
