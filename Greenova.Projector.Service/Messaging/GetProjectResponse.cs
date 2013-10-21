using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Greenova.Projector.Model;
using Greenova.Projector.Service.ViewModels;

namespace Greenova.Projector.Service.Messaging
{
    public class GetProjectResponse : ResponseBase
    {
        public ProjectAssignmentsViewModel ProjectAssignments { get; set; }

        public AssignProjectInputModel AssignProject { get; set; }

        public Project Project { get; set; }
    }
}
