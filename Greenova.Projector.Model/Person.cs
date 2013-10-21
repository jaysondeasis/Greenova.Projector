using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greenova.Projector.Model
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public IList<Project> AssignedProjects { get; set; }

        public string Name 
        { 
            get { return FirstName + " " + LastName; } 
        }
    }
}
