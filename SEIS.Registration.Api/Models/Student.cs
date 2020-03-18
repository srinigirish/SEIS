using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEIS.Registration.Api.Enums;

namespace SEIS.Registration.Api.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set;}
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<EnrolledCourses> Courses { get; set; }
    }
   
}
