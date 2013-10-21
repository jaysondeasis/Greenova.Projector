using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Greenova.Projector.Model.IRepositories;
using Greenova.Projector.EFRepository.Mapper;

namespace Greenova.Projector.EFRepository
{
    public class PersonRepository : IPersonRepository
    {
        private GreenovaEntities _entities;

        public Model.Person FindBy(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Person> FindAll()
        {
            IEnumerable<Model.Person> persons;

            using (_entities = new GreenovaEntities())
            {
                persons = _entities.Persons.ConvertToModelPersons();
            }
            
            return persons;
        }

        public void Save(Model.Person entity)
        {
            using (_entities = new GreenovaEntities())
            {
                if (entity.Id == 0)
                {
                    EFRepository.Person dbEntry = new EFRepository.Person
                    {
                        id = entity.Id,
                        first_name = entity.FirstName,
                        last_name = entity.LastName,
                        username = entity.Username,
                        password = entity.Password
                    };

                    _entities.Persons.AddObject(dbEntry);
                }
                else
                {
                    EFRepository.Person dbEntry = _entities.Persons.Where(x => x.id == entity.Id)
                        .SingleOrDefault();

                    if (dbEntry != null)
                    {
                        dbEntry.first_name = entity.FirstName;
                        dbEntry.last_name = entity.LastName;
                        dbEntry.username = entity.Username;
                        dbEntry.password = entity.Password;
                    }
                }

                _entities.SaveChanges();
            }
        }
    }
}
