using Oshxonaoptimized.Data.Repositories;
using Oshxonaoptimized.Domain.Entitites;

var obj = new Mealmodel()
{
    Id = 1,
    Nomi = "asasasas",
    Porsiyasi = 2
};
var service = new Repository();
var service1 = new Countting();
await service1.Selling(1, obj);
