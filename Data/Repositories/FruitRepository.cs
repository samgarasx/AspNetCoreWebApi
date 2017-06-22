using System;
using System.Collections.Generic;
using AspNetCoreWebApi.Data.Datasources;
using AspNetCoreWebApi.Models;

namespace AspNetCoreWebApi.Data.Repositories
{
    public class FruitRepository : IFruitRepository
    {
        private readonly IFruitDatasource datasource;

        public FruitRepository(IFruitDatasource datasource)
        {
            this.datasource = datasource;
        }

        public IEnumerable<Fruit> GetAll()
        {
            return this.datasource.GetAll();
        }

        public Fruit GetById(int id)
        {
            return this.datasource.GetById(id);
        }

        public Fruit Add(Fruit fruit)
        {
            return this.datasource.Add(fruit);
        }

        public void Update(Fruit fruit)
        {
            var oldFruit = this.datasource.GetById(fruit.Id);
            this.datasource.Update(oldFruit, fruit);
        }

        public void Delete(int id)
        {
            var fruit = this.datasource.GetById(id);
            this.datasource.Delete(fruit);
        }
    }
}