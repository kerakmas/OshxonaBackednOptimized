using Oshxonaoptimized.Data.Repositories;
using Oshxonaoptimized.Domain.Entitites;

public class Countting
{
    public async Task<Mealmodel> Selling(int porsiya, Mealmodel mealmodel)
    {
        Repository repository = new Repository();
        var existingMealModel = await repository.GetByIdAsync(mealmodel.Id);

        if (existingMealModel != null && existingMealModel.Porsiyasi >= porsiya)
        {
            existingMealModel.Porsiyasi -= porsiya;
            await repository.UpdateAsync(existingMealModel.Id, existingMealModel);
        }

        return existingMealModel;
    }

}