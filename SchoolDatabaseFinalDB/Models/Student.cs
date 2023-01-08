using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolDatabaseFinalDB.Models
{
    public partial class Student
    {
        public Student()
        {
            Course = new HashSet<Course>();
        }

        public int StudentId { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string StudentGrade { get; set; }
        public DateTime? GradeDate { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
