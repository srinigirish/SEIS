using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIS.Enrollment.Api.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MaxStudents { get; set; }

        public int FacultyId { get; set; }
 
        public ICollection<CourseSchedule> Schedules { get; set; }
    }
}
