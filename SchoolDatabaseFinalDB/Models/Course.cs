using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolDatabaseFinalDB.Models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int? FkStudentId { get; set; }
        public int? FkEmployeeId { get; set; }

        public virtual Employee FkEmployee { get; set; }
        public virtual Student FkStudent { get; set; }
    }
}
