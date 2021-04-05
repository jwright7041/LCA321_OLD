using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
                private static readonly List<Person> _people = new List<Person>
         {
             new Person
             {
                 Id = 1,
                 Name = "Luke Skywalker",
                 HairColor = "blond"
             },
             new Person
             {
                 Id = 2,
                 Name = "Leia Organa",
                 HairColor = "brown"
             },
             new Person
             {
                 Id = 3,
                 Name = "Han Solo",
                 HairColor = "brown"
             },
         };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_people);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            person.Id = _people.Count + 1;
            _people.Add(person);

            return CreatedAtAction("Post", person);
        }
    }
}
