using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask1.Models;

namespace WebApiTask1.Services
{
    public interface IPersonService
    {
        List<Person> Read();
        Person Read(string id);
    }
}
