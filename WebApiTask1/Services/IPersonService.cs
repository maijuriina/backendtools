﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask1.Models;

namespace WebApiTask1.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        List<Person> Read();
        Person Read(string id);
        Person Update(Person person);
        Person Delete(Person person);
    }
}
