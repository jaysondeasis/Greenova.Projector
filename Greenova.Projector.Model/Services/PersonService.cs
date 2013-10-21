using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Greenova.Projector.Model.IRepositories;

namespace Greenova.Projector.Model.Services
{
    public class PersonService
    {
        private IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person GetPerson(int id)
        {
            return _personRepository.FindBy(id);
        }
        
        public IEnumerable<Person> GetAllPersons()
        {
            return _personRepository.FindAll();
        }

        public void AddPerson(Person person)
        {
            _personRepository.Save(person);
        }       
    }
}
