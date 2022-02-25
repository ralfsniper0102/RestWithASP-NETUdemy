﻿using ScaffoldViaVisualStudio.Controllers.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ScaffoldViaVisualStudio.Services.Implamatation
{
    public class PersonServiceImplamentation : IPersonServices
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Leandro",
                LastName = "Costa",
                Address = "Uberllandia - Minas Gerais - Brasil",
                Gender = "Male"
            };

        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name" + 1,
                LastName = "Person LastName" + 1,
                Address = "Some Address" + 1,
                Gender = "Male"
            };
 
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
