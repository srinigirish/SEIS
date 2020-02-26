using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Custom Namespaces
using SEIS.Identity.Api.Models;

namespace SEIS.Identity.Api.Services.Interfaces
{
    /// <summary>
    /// IAuthenticate interface definition
    /// Input parameters for method signature are username and password
    /// Output is JWT AuthenticationSecurityToken
    /// </summary>
    public interface IAuthenticate
    {
        AuthenticationSecurityToken Authenticate(string userName, string password);
    }
}
