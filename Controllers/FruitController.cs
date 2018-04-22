using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApi.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebApi.Models;
using Newtonsoft.Json.Linq;
using AspNetCoreWebApi.Helpers;
using Newtonsoft.Json;

namespace AspNetCoreWebApi.Controllers
{
    [Route("api/fruits")]
    public class FruitController : Controller
    {
        private readonly IFruitRepository repository;

        public FruitController(IFruitRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var fruits = this.repository.FindAll().ToList();

            var jsonResponse = JsonResponse<List<Fruit>>.Success(fruits);

            return Ok(jsonResponse);
        }  

        [HttpGet("{id}", Name = "GetFruit")]
        public IActionResult GetById(int id)
        {
            var jsonResponse = new JsonResponse<Fruit>();

            var fruit = this.repository.FindById(id);
            if (fruit is null)
            {
                jsonResponse = JsonResponse<Fruit>.Failure("Fruit does not exists");

                return Ok(jsonResponse);
            }

            jsonResponse = JsonResponse<Fruit>.Success(fruit);
            
            return Ok(jsonResponse);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Fruit fruit)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var createdFruit = this.repository.Create(fruit);

            var jsonResponse = JsonResponse<Fruit>.Success(createdFruit);     

            return CreatedAtRoute("GetFruit", 
                new 
                { 
                    id = createdFruit.Id, 
                    name = createdFruit.No, 
                    description = createdFruit.Description 
                }, jsonResponse);    
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody]Fruit fruit)
        {
            var jsonResponse = new JsonResponse<Fruit>();

            if (!ModelState.IsValid)
                return BadRequest();

            var oldFruit = this.repository.FindById(id);
            if (oldFruit is null)
            {
                jsonResponse = JsonResponse<Fruit>.Failure("Fruit does not exists");

                return Ok(jsonResponse);
            }

            oldFruit.No = fruit.No;
            oldFruit.Description = fruit.Description;

            this.repository.Update(oldFruit);

            jsonResponse = JsonResponse<Fruit>.Success(fruit);

            return Ok(jsonResponse);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var jsonResponse = new JsonResponse<Fruit>();

            var fruit = this.repository.FindById(id);
            if (fruit is null)
            {
                jsonResponse = JsonResponse<Fruit>.Failure("Fruit does not exists");

                return Ok(jsonResponse);
            }

            this.repository.Delete(fruit);

            jsonResponse = JsonResponse<Fruit>.Success(fruit);

            return Ok(jsonResponse);
        }
    }
}
