using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greenova.Projector.Model
{
    public class Project
    {
        public Project()
        {
            AssignedPersons = new List<Person>();
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Remarks { get; set; }

        public decimal Budget { get; set; }

        public IList<Person> AssignedPersons { get; set; }

        public bool CanAssignPerson(int personId)
        {
            int count = AssignedPersons.Where(x => x.Id == personId).Count();
            if (count > 0)
                return true;

            return false;
        }        
    }
}
