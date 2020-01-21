using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask1.Models;

namespace WebApiTask1.Repositories
{
    public interface IPersonRepository
    {
        Person Create(Person person); // returns Person, otherwise would be void
        List<Person> Read();
        Person Read(string id);
        Person Update(Person personToUpdate);
        void Delete(Person personToDelete);
    }
}
