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

        public Person Create(Person person) // person comes from front end
        {
            Person newPerson = new Person();
            newPerson.Name = "Terho Taisto";
            newPerson.Age = 47;
            // with SQL use InsertInto
            _persondbContext.Person.Add(newPerson);
            _persondbContext.SaveChanges();
            return newPerson;
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

        public Person Update(string id)
        {
            throw new NotImplementedException();
        }


        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
