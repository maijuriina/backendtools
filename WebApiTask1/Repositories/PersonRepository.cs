using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask1.Data;
using WebApiTask1.Models;

namespace WebApiTask1.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        // injected database
        private readonly PersondbContext _persondbContext;

        // define constructor
        public PersonRepository(PersondbContext persondbContext) // is implemented when calling through service class
        {
            _persondbContext = persondbContext;
        }

        public List<Person> Read() // searches all users
        {
            var users = _persondbContext.Person.ToList();
            return users; // you can also return _persondbContext.. straight away, but saved to var users for testing
        }

        public Person Read(string id) // searches for specific user with id
        {
            var user = _persondbContext.Person.FirstOrDefault(p => p.Id == id);
            return user;
        }
    }
}
