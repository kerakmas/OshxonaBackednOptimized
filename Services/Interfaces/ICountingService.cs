
using Oshxonaoptimized.Domain.Entitites;

namespace Oshxonaoptimized.Services.Interfaces
{
    public interface ICountingService
    {
        Task<Mealmodel> Selling(int porsiya,Mealmodel mealmodel);

    }
}
