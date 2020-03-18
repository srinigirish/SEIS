using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIS.Enrollment.Api.Models
{
    public class CourseVenue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public int CourseScheduleId { get; set; }
    }
}
