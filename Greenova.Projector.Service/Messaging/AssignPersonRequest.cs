using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greenova.Projector.Service.Messaging
{
    public class AssignPersonRequest
    {
        public int PersonId { get; set; }

        public int ProjectId { get; set; }
    }
}
