using System.Collections.Generic;
using System.Linq;

namespace GamesChampionship.Domain.Models
{
    public class Championship
    {
        public IList<Round> Rounds { get; private set; }

        public Game Winner
        {
            get
            {
                return Rounds.Last().Matches.Last().WinnerGame;
            }
        }

        public Championship(IEnumerable<Game> games)
        {
            this.DefineChampionship(games);
        }

        private void DefineChampionship(IEnumerable<Game> games)
        {
            Rounds = new List<Round>();

            games = ToAlphabeticOrder(games);

            int roundPosition = 1;

            do
            {
                List<Match> justFinishedMatches = PerformRoundMatches(games);

                Round currentRound = new Round(justFinishedMatches, roundPosition);
                Rounds.Add(currentRound);

                games = DefineGamesForTheNextRound(games, currentRound);

                roundPosition++;

            } while (games.Count() != 1);
        }

        private List<Match> PerformRoundMatches(IEnumerable<Game> gamesInTheRound)
        {
            List<Match> matches = new List<Match>();

            int matchPosition = 1;

            do
            {
                Game firstGame = gamesInTheRound.First();
                Game lastGame = gamesInTheRound.Last();

                Match newMatch = new Match(firstGame, lastGame, matchPosition);

                matches.Add(newMatch);

                matchPosition++;

            } while (OneMoreMatchMustBePerformed(gamesInTheRound, matches));

            return matches;
        }

        private IOrderedEnumerable<Game> ToAlphabeticOrder(IEnumerable<Game> games)
        {
            return games.OrderBy(game => game.Title);
        }

        private bool OneMoreMatchMustBePerformed(IEnumerable<Game> gamesInTheRound, List<Match> performedMatches)
        {
            return performedMatches.Count() == (gamesInTheRound.Count() / 2);
        }

        private IEnumerable<Game> DefineGamesForTheNextRound(IEnumerable<Game> remainingGames, Round round)
        {
            remainingGames = remainingGames.Except(round.Matches.Select(match => match.LoserGame));

            return remainingGames;
        }
    }
}
