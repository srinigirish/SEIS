using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIS.Enrollment.Api.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }
        public IEnumerable<FacultyQualification> Qualifications { get; set; }
    }
}
