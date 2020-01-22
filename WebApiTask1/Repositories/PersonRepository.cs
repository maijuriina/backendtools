using Microsoft.EntityFrameworkCore;
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
            // 1. INSERT adds person to Person-table
            // 2. SELECT read and save person's ID
            // 3. INSERT adds phone numbers to Phone-table, key is ID
            _persondbContext.Person.Add(person);
            _persondbContext.SaveChanges();
            return person;
        }

        public List<Person> Read() // searches all users
        {
            // SELECT * FROM PERSON
            // LEFT OUTER JOIN
            // Phone ON Person.Id = Phone.PersonId
            // SQL-INJECTION DANGER: WHERE Person.Id = 'SELECT ...' as string emitted can be an SQL command
            var users = _persondbContext.Person
                .Include(p=>p.Phone)
                .ToList();
            return users; // you can also return _persondbContext.. straight away, but saved to var users for testing
        }

        public Person Read(string id) // searches for specific user with id
        {
            var user = _persondbContext.Person.FirstOrDefault(p => p.Id == id);
            return user;
        }

        public Person Update(Person personToUpdate)
        {
            _persondbContext.Person.Update(personToUpdate);
            _persondbContext.SaveChanges();
            return personToUpdate;
        }

        public void Delete(Person personToDelete)
        {
            _persondbContext.Person.Remove(personToDelete);
            _persondbContext.SaveChanges();
        }
    }
}
