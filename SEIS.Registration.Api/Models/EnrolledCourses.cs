using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIS.Registration.Api.Models
{
    public class EnrolledCourses
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
