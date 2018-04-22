using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApi.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebApi.Models;
using Newtonsoft.Json.Linq;

namespace AspNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class FruitsController : Controller
    {
        private readonly IFruitRepository repository;

        public FruitsController(IFruitRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var fruits = this.repository.FindAll();

            var jsonResponse = new JObject(
                new JProperty("ok", true),
                new JProperty("msg", new JArray(
                    from fruit in fruits
                    select new JObject(
                        new JProperty("id", fruit.Id),
                        new JProperty("no", fruit.No),
                        new JProperty("description", fruit.Description)
                    )
                ))
            );

            return Ok(jsonResponse);
        }  

        [HttpGet("{id}", Name = "GetFruit")]
        public IActionResult GetById(int id)
        {
            var fruit = this.repository.FindById(id);
            if (fruit is null)
                return NotFound();

            var jsonResponse = new JObject(
                new JProperty("ok", true),
                new JProperty("msg", new JObject(
                    new JProperty("id", fruit.Id),
                    new JProperty("no", fruit.No),
                    new JProperty("description", fruit.Description)
                ))
            );
            
            return Ok(jsonResponse);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Fruit fruit)
        {
            if (fruit is null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            var createdFruit = this.repository.Create(fruit);

            var jsonResponse = new JObject(
                new JProperty("ok", true),
                new JProperty("msg", new JObject(
                    new JProperty("id", createdFruit.Id),
                    new JProperty("no", createdFruit.No),
                    new JProperty("description", createdFruit.Description)
                ))
            );       

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
            var jsonResponse = new JObject();

            if (fruit is null)
                return BadRequest();

            if (fruit.Id != id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            var oldFruit = this.repository.FindById(id);
            if (oldFruit is null)
            {
                jsonResponse = new JObject(
                    new JProperty("ok", false),
                    new JProperty("msg", "Fruit does not exists")
                );

                return Ok(jsonResponse);
            }

            oldFruit.No = fruit.No;
            oldFruit.Description = fruit.Description;

            this.repository.Update(oldFruit);

            jsonResponse = new JObject(
                new JProperty("ok", true),
                new JProperty("msg", new JObject(
                    new JProperty("id", fruit.Id),
                    new JProperty("no", fruit.No),
                    new JProperty("description", fruit.Description)
                ))
            );

            return Ok(jsonResponse);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var jsonResponse = new JObject();

            var fruit = this.repository.FindById(id);
            if (fruit is null)
            {
                jsonResponse = new JObject(
                    new JProperty("ok", false),
                    new JProperty("msg", "Fruit does not exists")
                );

                return Ok(jsonResponse);
            }

            this.repository.Delete(fruit);

            jsonResponse = new JObject(
                new JProperty("ok", true),
                new JProperty("msg", new JObject(
                    new JProperty("id", fruit.Id),
                    new JProperty("no", fruit.No),
                    new JProperty("description", fruit.Description)
                ))
            );

            return Ok(jsonResponse);
        }
    }
}
