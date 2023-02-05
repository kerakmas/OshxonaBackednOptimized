using Newtonsoft.Json;
using Oshxonaoptimized.Data.Configurations;
using Oshxonaoptimized.Data.IRepostiories;
using Oshxonaoptimized.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Oshxonaoptimized.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly string path = Configuration.MAIN_PATH;
        
        public async Task<Mealmodel> CreateAsync(Mealmodel mealModel)
        {
            List<Mealmodel> mealModels = new List<Mealmodel>();
            if (File.Exists(path))
            {
                string json = await File.ReadAllTextAsync(path);
                mealModels = JsonConvert.DeserializeObject<List<Mealmodel>>(json) ?? new List<Mealmodel>();
            }

            mealModels.Add(mealModel);
            string newJson = JsonConvert.SerializeObject(mealModels);
            await File.WriteAllTextAsync(path, newJson);

            return mealModel;
        }





        public async Task<bool> DeleteAsync(int id)
        {
            string json = await File.ReadAllTextAsync(path);
            List<Mealmodel> mealModels = JsonConvert.DeserializeObject<List<Mealmodel>>(json);
            var mealModel = mealModels.FirstOrDefault(x => x.Id == id);
            if (mealModel == null)
            {
                return false;
            }
            mealModels.Remove(mealModel);
            json = JsonConvert.SerializeObject(mealModels);
            await File.WriteAllTextAsync(path, json);
            return true;
        }


        public async Task<List<Mealmodel>> GetAllAsync()
        {
            string json = await File.ReadAllTextAsync(path);
            List<Mealmodel> mealModels = JsonConvert.DeserializeObject<List<Mealmodel>>(json);
            return mealModels;
        }


        public async Task<Mealmodel> GetByIdAsync(int id)
        {
            var res = await GetAllAsync();
            var les = res.FirstOrDefault(x => x.Id == id);
            return les;

        }

        public async Task<Mealmodel> GetByNameAsync(string name)
        {
            var res = await GetAllAsync();
            var les = res.FirstOrDefault(x => x.Nomi == name);
            return les;
            
        }

        public async Task<Mealmodel> UpdateAsync(int id, Mealmodel mealmodel)
        {
            string json = await File.ReadAllTextAsync(path);
            List<Mealmodel> mealModels = JsonConvert.DeserializeObject<List<Mealmodel>>(json);
            var existingMealModel = mealModels.FirstOrDefault(x => x.Id == id);
            if (existingMealModel == null)
            {
                return null;
            }

            mealModels.Remove(existingMealModel);
            mealModels.Add(mealmodel);
            json = JsonConvert.SerializeObject(mealModels);
            await File.WriteAllTextAsync(path, json);
            return mealmodel;
        }

    }
}
