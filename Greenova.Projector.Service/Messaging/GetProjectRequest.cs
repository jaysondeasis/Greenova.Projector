using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greenova.Projector.Service.Messaging
{
    public class GetProjectRequest
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool All { get; set; }
    }
}
