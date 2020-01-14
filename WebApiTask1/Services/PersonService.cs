using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask1.Models;
using WebApiTask1.Repositories;

namespace WebApiTask1.Services
{
    public class PersonService : IPersonService
    {
        // inject repository layer
        private readonly IPersonRepository _personRepository;

        // define constructor
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person Create(Person person)
        {
            throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            return _personRepository.Read();
        }

        public Person Read(string id)
        {
            return _personRepository.Read(id);
        }

        public void Update(string id)
        {
            Person personToUpdate = _personRepository.Read(id);
            personToUpdate.Name = "Oiva Uutukainen";
            personToUpdate.Age = 11;
            _personRepository.Update(personToUpdate);
        }

        public void Delete(string id)
        {
            Person personToDelete = _personRepository.Read(id);
            _personRepository.Delete(personToDelete);
        }
    }
}
