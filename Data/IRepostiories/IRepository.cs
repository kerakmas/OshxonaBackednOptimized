using Oshxonaoptimized.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oshxonaoptimized.Data.IRepostiories
{
    public interface IRepository
    {
        Task<Mealmodel> CreateAsync(Mealmodel mealmodel);
        Task<List<Mealmodel>> GetAllAsync();
        Task<Mealmodel> GetByIdAsync(int id);
        Task<Mealmodel> UpdateAsync(int id,Mealmodel mealmodel);
        Task<bool> DeleteAsync(int id);
        Task<Mealmodel> GetByNameAsync(string name);
    }
}
