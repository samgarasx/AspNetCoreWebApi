using AspNetCoreWebApi.Models;
using System.Collections.Generic;

namespace AspNetCoreWebApi.Data.Datasources
{
    public interface IFruitDatasource
    {
         IEnumerable<Fruit> GetAll();
         Fruit GetById(int id);
         Fruit Add(Fruit fruit);
         void Update(Fruit oldFruit, Fruit fruit);
         void Delete(Fruit fruit);
    }
}