namespace GamesChampionship.Domain.Models
{
    public class Match
    {
        public Game WinnerGame { get; private set; }

        public Game LoserGame { get; private set; }

        public int Position { get; private set; }

        public Match(Game gameOne, Game gameTwo, int positionInRound)
        {
            this.Position = positionInRound;
            this.DefineMatch(gameOne, gameTwo);
        }

        private Match DefineMatch(Game firstGame, Game secondGame)
        {
            double firstGameNote = firstGame.Note;
            double secondGameNote = secondGame.Note;

            if (firstGameNote > secondGameNote)
            {
                return SetWinnerAndLoser(firstGame, secondGame);
            }
            else if (firstGameNote < secondGameNote)
            {
                return SetWinnerAndLoser(secondGame, firstGame);
            }

            int firstGameYear = firstGame.Year;
            int secondGameYear = secondGame.Year;

            if (firstGameYear == secondGameYear)
            {
                return SetWinnerAndLoser(firstGame, secondGame);
            }
            else
            {
                if (firstGameYear > secondGameYear)
                {
                    return SetWinnerAndLoser(firstGame, secondGame);
                }
                else
                {
                    return SetWinnerAndLoser(secondGame, firstGame);
                }
            }
        }

        private Match SetWinnerAndLoser(Game winnerGame, Game loserGame)
        {
            this.WinnerGame = winnerGame;
            this.LoserGame = loserGame;

            return this;
        }
    }
}
