using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolDatabaseFinalDB.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Course = new HashSet<Course>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeRole { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfEmp { get; set; }
        public int? EmployeeSalary { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
