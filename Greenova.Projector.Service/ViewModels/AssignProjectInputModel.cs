using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Greenova.Projector.Model;

namespace Greenova.Projector.Service.ViewModels
{
    public class AssignProjectInputModel
    {
        public Project Project { get; set; }

        public IEnumerable<Person> PersonsToAssign { get; set; }

        public Person Person { get; set; }
    }
}
