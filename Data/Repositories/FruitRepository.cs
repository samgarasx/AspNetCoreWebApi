using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreWebApi.Models;

namespace AspNetCoreWebApi.Data.Repositories
{
    public class FruitRepository : IFruitRepository
    {
        private readonly FruitContext context;

        public FruitRepository(FruitContext context)
        {
            this.context = context;
        }

        public IEnumerable<Fruit> FindAll()
        {
            return this.context.Fruits.ToList();
        }

        public Fruit FindById(int id)
        {
            return this.context.Fruits.SingleOrDefault(f => f.Id == id);
        }

        public Fruit Create(Fruit fruit)
        {
            this.context.Fruits.Add(fruit);
            this.context.SaveChanges();

            return fruit;
        }

        public void Update(Fruit fruit)
        {
            this.context.Fruits.Update(fruit);
            this.context.SaveChanges();
        }

        public void Delete(Fruit fruit)
        {
            this.context.Fruits.Remove(fruit);
            this.context.SaveChanges();
        }
    }
}