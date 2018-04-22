using AspNetCoreWebApi.Models;
using System.Collections.Generic;

namespace AspNetCoreWebApi.Data.Repositories
{
    public interface IFruitRepository
    {
         IEnumerable<Fruit> FindAll();
         Fruit FindById(int id);
         Fruit Create(Fruit fruit);
         void Update(Fruit fruit);
         void Delete(Fruit fruit);
    }
}