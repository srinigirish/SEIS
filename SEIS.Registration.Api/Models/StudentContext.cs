using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SEIS.Registration.Api.Models
{
    /// <summary>
    /// StudentDb Context class using EF
    /// </summary>
    public class StudentContext :DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
          : base(options) { }

        // The set of Students 
        public DbSet<Student> Students { get; set; }
        // The set of Enrolled Courses 
        //public DbSet<EnrolledCourses> EnrolledCourse { get; set; }
        // The set of Addresses
        //public DbSet<Address> Addresses { get; set; }

    }
}
