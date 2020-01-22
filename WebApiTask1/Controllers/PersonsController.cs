using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTask1.Models;
using WebApiTask1.Repositories;
using WebApiTask1.Services;

namespace WebApiTask1.Controllers
{
    [Route("users")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        // inject repository layer through interface
        private readonly IPersonRepository _personRepository;

        // inject service layer
        private readonly IPersonService _personService;

        // define constructor
        public PersonsController(IPersonRepository personRepository, IPersonService personService)
        {
            _personRepository = personRepository;
            _personService = personService;
        }


        // GET: api/Persons
        [HttpGet]
        public IActionResult Get() // IActionResult does not know what is returned
        {
            var result = _personService.Read();
            return new JsonResult(result); // returns result in json-format back to front
        }

        // GET: api/Persons/id
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            var result = _personRepository.Read(id);
            return new JsonResult(result);
        }

        // POST: api/Persons
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            var result = _personService.Create(person);
            return new JsonResult(result);
        }

        // PUT: api/Persons/5
        [HttpPut("{id}")]
        //public void Put(string id, [FromBody] string value)
        public IActionResult Put(Person person)
        {
            var result = _personService.Update(person);
            return new JsonResult(result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _personService.Delete(id);
        }
    }
}
