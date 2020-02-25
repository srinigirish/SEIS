using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIS.Identity.Api.Models
{
    /// <summary>
    /// User class holding the login credentials and other details
    /// </summary>
    public class User
    {
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
    }
}
