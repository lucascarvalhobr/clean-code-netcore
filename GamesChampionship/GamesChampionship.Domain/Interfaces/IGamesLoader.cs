using GamesChampionship.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesChampionship.Domain.Interfaces
{
    public interface IGamesLoader
    {
        Task<List<Game>> Load();
    }
}
