using System.Collections.Generic;
using System.Threading;
using Calculadora.Model;

namespace Calculadora.Services.Implementations
{
    public class PersonService : IPersonService
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
                persons.Add(new Person()
                {
                    Id = IncrementAdnGet(),
                    FirstName = "Pessoa " + i,
                    LastName = "Pessoa " + i,
                    Address = "Endereco " + i,
                    Gender = "Male"
                });
            }

            return persons;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Leandro",
                LastName = "Facchini",
                Address = "Avenida Casa Grande",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private long IncrementAdnGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}