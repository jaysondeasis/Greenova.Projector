using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greenova.Projector.Infrastructure.Authentication
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
