using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIS.Enrollment.Api.Models
{
    public class FacultyQualification
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime GraduationDate { get; set; }
        public string University { get; set; }

    }
}
