using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greenova.Projector.EFRepository.Mapper
{
    public static class PersonExtensionMethods
    {
        public static Model.Person ConvertToModelPerson(this EFRepository.Person person)
        {
            return new Model.Person
            {
                Id = person.id,
                FirstName = person.first_name,
                LastName = person.last_name,
                Username = person.username,
                Password = person.password,
                AssignedProjects = person.Projects.ConvertToModelProjects().ToList()
            };
        }

        public static IEnumerable<Model.Person> ConvertToModelPersons(this IEnumerable<EFRepository.Person> persons)
        {
            IList<Model.Person> modelPerson = new List<Model.Person>();

            foreach (EFRepository.Person project in persons)
            {
                modelPerson.Add(project.ConvertToModelPerson());
            }

            return modelPerson.AsEnumerable();
        }
    }
}
