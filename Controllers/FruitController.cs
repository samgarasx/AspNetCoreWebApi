using AspNetCoreWebApi.Entities;
using AspNetCoreWebApi.Helpers;
using AspNetCoreWebApi.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    [Route("api/fruits")]
    public class FruitController : Controller
    {
        private readonly FruitContext _context;

        public FruitController(FruitContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult All()
        {
            var fruits = _context.Fruits.Select(fruitEntity => new Fruit
            {
                Id = fruitEntity.Id,
                No = fruitEntity.No,
                Description = fruitEntity.Description
            }).ToList();

            var jsonResponse = JsonResponse<List<Fruit>>.Success(fruits);

            return Ok(jsonResponse);
        }  

        [HttpGet("{id}", Name = "GetFruit")]
        public IActionResult One(int id)
        {
            JsonResponse<Fruit> jsonResponse;

            var fruitEntity = _context.Fruits.Find(id);
            
            if (fruitEntity is null)
            {
                jsonResponse = JsonResponse<Fruit>.Failure("Fruit does not exists");
            }
            else
            {
                var fruit = new Fruit
                {
                    Id = fruitEntity.Id,
                    No = fruitEntity.No,
                    Description = fruitEntity.Description
                };
                
                jsonResponse = JsonResponse<Fruit>.Success(fruit);
            }
  
            return Ok(jsonResponse);
        }

        [HttpPost]
        public IActionResult New([FromBody]Fruit fruit)
        {
            JsonResponse<Fruit> jsonResponse;
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var fruitEntity = _context.Fruits.SingleOrDefault(f => f.No == fruit.No);
            
            if (fruitEntity is null)
            {
                fruitEntity = new FruitEntity()
                {
                    No = fruit.No,
                    Description = fruit.Description
                };
                
                 _context.Fruits.Add(fruitEntity);
                _context.SaveChanges();

                fruit.Id = fruitEntity.Id;

                jsonResponse = JsonResponse<Fruit>.Success(fruit);
            }
            else
            {
                jsonResponse = JsonResponse<Fruit>.Failure("Fruit already exists");
            }

            return Ok(jsonResponse);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody]Fruit fruit)
        {
            JsonResponse<Fruit> jsonResponse;

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var fruitEntity = _context.Fruits.Find(id);
            
            if (fruitEntity is null)
            {
                jsonResponse = JsonResponse<Fruit>.Failure("Fruit does not exists");
            }
            else
            {
                fruitEntity.Description = fruit.Description;
                
                _context.Fruits.Update(fruitEntity);
                _context.SaveChanges();

                fruit.Id = fruitEntity.Id;
                fruit.No = fruitEntity.No;
                
                jsonResponse = JsonResponse<Fruit>.Success(fruit);
            }

            return Ok(jsonResponse);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            JsonResponse<Fruit> jsonResponse;

            var fruitEntity = _context.Fruits.Find(id);
            
            if (fruitEntity is null)
            {
                jsonResponse = JsonResponse<Fruit>.Failure("Fruit does not exists");
            }
            else
            {
                var fruit = new Fruit
                {
                    Id = fruitEntity.Id,
                    No = fruitEntity.No,
                    Description = fruitEntity.Description
                };
                
                _context.Fruits.Remove(fruitEntity);
                _context.SaveChanges();
                
                jsonResponse = JsonResponse<Fruit>.Success(fruit);
            }

            return Ok(jsonResponse);
        }
    }
}
