using System;
using System.Collections.Generic;
using AspNetCoreWebApi.Data.Datasources;
using AspNetCoreWebApi.Models;

namespace AspNetCoreWebApi.Data.Repositories
{
    public class FruitRepository : IFruitRepository
    {
        private readonly IFruitDataSource dataSource;

        public FruitRepository(IFruitDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public IEnumerable<Fruit> GetAll()
        {
            return this.dataSource.GetAll();
        }

        public Fruit GetById(int id)
        {
            return this.dataSource.GetById(id);
        }

        public Fruit Add(Fruit fruit)
        {
            return this.dataSource.Add(fruit);
        }

        public void Update(Fruit fruit)
        {
            var oldFruit = this.dataSource.GetById(fruit.Id);
            this.dataSource.Update(oldFruit, fruit);
        }

        public void Delete(int id)
        {
            var fruit = this.dataSource.GetById(id);
            this.dataSource.Delete(fruit);
        }
    }
}