//Martin Karlsson NET22
//SchoolDatabase Uppgift 4, slut projekt
using SchoolDatabaseFinalDB.Data;
using SchoolDatabaseFinalDB.Models;
using System.Linq;
using System;

namespace SchoolDatabaseDB
{
    class Program
    {

        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        public static bool MainMenu() // Writelines acts as the face for the manu
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) View all Student information");
            Console.WriteLine("2) View all active Courses");
            Console.WriteLine("3) Add a new Employee");
            Console.WriteLine("4) View teacher courses");
            Console.WriteLine("5) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine()) // Checks what option the user selects 1-5 and result changes depening on which case
            {
                case "1":
                    ViewEmployees();
                    return true;
                case "2":
                    ViewCourse();
                    return true;
                case "3":
                    AddEmployees();
                    return true;
                case "4":
                    ViewTeachers();
                    return true;
                case "5":
                    return false;
                default:
                    return true;
            }
        }

        public static string CaptureInput() // Method used to return the user to the main menu
        {
            Console.Write("Press Enter to return to the main menu ");
            return Console.ReadLine();
        }

        public static void ViewEmployees() // C# Methods using LINQ to retrieve data in the database, then used in the menu options
        {
            Console.Clear();
            using (var context = new SchoolDbContext())
            {
                var myStudents = from c in context.Student
                                 select c;
                foreach (var student in myStudents)
                {
                    Console.WriteLine("Student name: " + student.FullName + "  " + student.StudentGrade + " " + student.GradeDate);
                }
            }
            CaptureInput();
        }

        public static void AddEmployees() // Another LINQ method, get the info from the user and then saves it onto the database
        {
            Console.Clear();
            Console.WriteLine("Enter your role: ");
            string InputRole = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter your full name: ");
            string InputName = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter your date of birth: ");
            DateTime InputDate = DateTime.Parse(Console.ReadLine());

            using SchoolDbContext context = new SchoolDbContext();
            Employee employee = new Employee();
            {
                employee.FullName = InputName;
                employee.EmployeeRole = InputRole;
                employee.DateOfBirth = InputDate;
            }
            context.Employee.Add(employee);
            context.SaveChanges();
            Console.WriteLine("You have successfully added a new employee user.");

            CaptureInput();
        }

        public static void ViewCourse() // Methods using LINQ to retrieve data in the database, then used in the menu options
        {
            Console.Clear();
            using (var context = new SchoolDbContext())
            {
                var myStudents = from stud in context.Student
                                 join cour in context.Course on stud.StudentId equals cour.FkStudentId
                                 select new
                                 {
                                     FullName = stud.FullName,
                                     StudentGrade = stud.StudentGrade,
                                     CourseName = cour.CourseName
                                 };
                foreach (var student in myStudents)
                {
                    Console.WriteLine(student.FullName + " " + student.StudentGrade + " " + student.CourseName);
                }
            }

            CaptureInput();
        }

        public static void ViewTeachers() // Methods using LINQ to retrieve data in the database, then used in the menu options
        {
            Console.Clear();
            using (var context = new SchoolDbContext())
            {
                var myStudents = from emp in context.Employee
                                 join cour in context.Course on emp.EmployeeId equals cour.FkEmployeeId
                                 select new
                                 {
                                     FullName = emp.FullName,
                                     EmployeeRole = emp.EmployeeRole,
                                     CourseName = cour.CourseName
                                 };
                foreach (var emps in myStudents)
                {
                    Console.WriteLine(emps.CourseName + " " + emps.FullName + " " + emps.EmployeeRole);
                }
            }

            CaptureInput();
        }

        public static void DisplayResult(string message)
        {
            Console.WriteLine($"\r\nYour modified string is: {message}");
            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();
        }
    }
}
