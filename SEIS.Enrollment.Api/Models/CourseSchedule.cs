using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIS.Enrollment.Api.Models
{
    public class CourseSchedule
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DurationInDays { get; set; }
        public decimal Fee { get; set; }
      public IEnumerable<CourseVenue> Venues { get; set; }
    }
}
