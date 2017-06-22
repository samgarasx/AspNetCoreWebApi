using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreWebApi.Models;

namespace AspNetCoreWebApi.Data.Datasources
{
    public class FruitDatasource : IFruitDatasource
    {
        private readonly FruitStoreContext context;

        public FruitDatasource(FruitStoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Fruit> GetAll()
        {
            return this.context.Fruits.ToList();
        }

        public Fruit GetById(int id)
        {
            return this.context.Fruits.Single(f => f.Id == id);
        }

        public Fruit Add(Fruit fruit)
        {
            this.context.Fruits.Add(fruit);
            this.context.SaveChanges();

            return fruit;
        }

        public void Update(Fruit oldFruit, Fruit fruit)
        {
            oldFruit.No = fruit.No;
            oldFruit.Description = fruit.Description;

            this.context.Fruits.Update(oldFruit);
            this.context.SaveChanges();
        }

        public void Delete(Fruit fruit)
        {
            this.context.Fruits.Remove(fruit);
            this.context.SaveChanges();
        }
    }
}