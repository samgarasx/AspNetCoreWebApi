using System.Collections.Generic;
using AspNetCoreWebApi.Models;

namespace AspNetCoreWebApi.Data.Repositories
{
    public interface IFruitRepository
    {
        IEnumerable<Fruit> GetAll();
        Fruit GetById(int id);
        Fruit Add(Fruit fruit);
        void Update(Fruit fruit);
        void Delete(int id);
    }
}