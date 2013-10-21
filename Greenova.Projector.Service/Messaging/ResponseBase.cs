using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greenova.Projector.Service.Messaging
{
    public abstract class ResponseBase
    {
        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
