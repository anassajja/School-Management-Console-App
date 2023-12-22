using System;
using System.Collections.Generic;

namespace SCHOOL_MANAGEMENT_CONSOLE_APP
{
    class Administrator : Person // Inherit from Person class
    {
        public string Grade { get; set; }
        public static List<string> WeekDays = new() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static List<string> WeeklySchedule { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static List<string> WeeklyTeacherSchedule { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string? ClassName { get; }
        public string? ModuleName { get; }
        public string? CourseName { get; }
        public DateTime DebutTime { get; }
        public DateTime EndTime { get; }
        public DateTime ExamDate { get; }
        public DateTime ProjectDeadLine { get; }

        public static List<string>? WeeklyStudentSchedule { get; set; }

        public static List<Administrator> Administrators = new();

        public static List<Administrator> ExamsDatesAndDeadlines = new();

        public static List<Administrator> UpcomingModulesAndCourses = new();

        public static List<Administrator> StudentPerformanceReports = new();

        public static List<Administrator> TeacherPerformanceReports = new();

        // Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Administrator(string firstName, string lastName, string gender, int id, int phoneNumber, string email, string address, DateTime dateOfBirth, string nationality, string grade, string? className, string? moduleName, string? courseName, DateTime examDate, DateTime projectDeadline) : base(firstName, lastName, gender, id, phoneNumber, email, address, dateOfBirth, nationality)
        {
            Grade = grade;
            ClassName = className;
            ModuleName = moduleName;
            CourseName = courseName;
            ExamDate = examDate;
            ProjectDeadLine = projectDeadline;
        }

        public static void ManageAdministration()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n==================================================\n");
            Console.WriteLine("                 Administrator Access");
            Console.WriteLine("\n==================================================\n");
            Console.WriteLine("1. Manage Students < ONLY ADMIN ACCESS ! >\n");
            Console.WriteLine("2. Manage Teachers < ONLY ADMIN ACCESS ! >\n");
            Console.WriteLine("3. Manage Modules < ONLY ADMIN ACCESS ! >\n");
            Console.WriteLine("4. Manage Courses < ONLY ADMIN ACCESS ! >\n");
            Console.WriteLine("5. Add Admininstrator < ONLY ADMIN ACCESS ! >\n");
            Console.WriteLine("6. Calendar and Schedule < ONLY ADMIN ACCESS ! >\n");
            Console.WriteLine("7. Generate Reports < ONLY ADMIN ACCESS ! >\n");
            Console.WriteLine("8. System Settings < ONLY ADMIN ACCESS ! >\n");
            Console.WriteLine("9. Back to main menu\n");
            Console.ResetColor(); // Reset color to default
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine('\n');

            switch (choice)
            {
                case 1:
                    Student.ManageStudents();
                    break;

                case 2:
                    Teacher.ManageTeachers();
                    break;

                case 3:
                    Module.ManageModules();
                    break;

                case 4:
                    Course.ManageCourses();
                    break;

                case 5:
                    AddAdministrator();
                    break;

                case 6:
                    CalendarAndSchedule();
                    break;

                case 7:
                    GenerateReports();
                    break;

                case 8:
                    SystemSettings();
                    break;

                case 9:
                    return; // Return to the main menu

                default:
                    Console.WriteLine("Invalid choice. Try again.\n");
                    break;
            }
        }

        private static void AddAdministrator()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("            Add Administrator             ");
            Console.WriteLine("\n****************************************\n");
            Console.Write("Enter Administrator First Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string firstName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.Write("\n");
            Console.Write("Enter Administrator Last Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string lastName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("Enter Administrtor Gender : ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string gender = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.Write("\n");
            Console.Write("Enter Administrator ID: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            int id = Convert.ToInt32(Console.ReadLine());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.Write("\n");
            Console.Write("Enter Administrator Phone Number: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            int phoneNumber = Convert.ToInt32(Console.ReadLine());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.  
            Console.Write("\n");
            Console.Write("Enter Administrator Email: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string email = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.Write("\n");
            Console.Write("Enter Administrator Address: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string address = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.Write("\n");
            Console.Write("Enter Administrator Date of Birth: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.Write("\n");
            Console.WriteLine("Enter Administrator Nationality: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string nationality = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.Write("\n");
            Console.WriteLine("Enter Administrator Grade: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string grade = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            #pragma warning disable CS8604 // Possible null reference argument.
            Administrator newAdmin = new(firstName, lastName, gender, id, phoneNumber, email, address, dateOfBirth, nationality, grade, null, null, null, DateTime.Now, DateTime.Now);
            #pragma warning restore CS8604 // Possible null reference argument.
            Administrators.Add(newAdmin);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAdministrator added successfully!\n");
            Console.ResetColor();
        }

        private static void CalendarAndSchedule()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("            Calendar and Schedule           ");
            Console.WriteLine("\n****************************************\n");
            Console.WriteLine("1. Manage Calendar < ONLY ADMIN ACCESS ! >\n");
            Console.WriteLine("2. Manage Weekly Schedule < ONLY ADMIN ACCESS ! >\n");
            Console.WriteLine("3. View Weekly Schedule\n"); 
            Console.WriteLine("4. View Calendar\n"); 
            Console.WriteLine("5. Back to Admin Menu\n");
            Console.ResetColor();
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    ManageCalender();
                    break;

                case 2:
                    ManageWeeklySchedule();
                    break;

                case 3:
                    ViewSchedule();
                    break;

                case 4:
                    ViewCalendar();
                    break;

                case 5:
                    return; // Return to the admin menu

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }
        }

        private static void ManageWeeklySchedule()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("            Manage Weekly Schedule             ");
            Console.WriteLine("\n****************************************\n");
            Console.WriteLine("1. Manage Weekly Students Schedule\n");
            Console.WriteLine("2. Manage Weekly Teachers Schedule\n");
            Console.WriteLine("3. Back To Calendar and Schedule Menu\n");
            Console.ResetColor();
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    ManageStudentSchedule();
                    break;

                case 2:
                    ManageTeacherSchedule();
                    break;

                case 3:
                    return; // Return to the Calendar and Schedule menu

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }
        }

        private static void ManageStudentSchedule()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************************\n");
            Console.WriteLine("            Manage Weekly Students Schedule             ");
            Console.WriteLine("\n*****************************************************\n");
            Console.WriteLine("Enter Weekly Students Schedule Class: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string className = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            foreach (var day in WeekDays)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Enter Weekly Students Schedule Details for {day}: ");
                Console.WriteLine("\n");
                Console.WriteLine("Enter Weekly Students Schedule Module: ");  
    #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string moduleName = Console.ReadLine();
    #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.WriteLine("Enter Weekly Students Schedule Course: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string courseName = Console.ReadLine();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.WriteLine("Enter Weekly Students Schedule Debut Time: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                DateTime DebutTime;
                DateTime.TryParse(Console.ReadLine(), out DebutTime);
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.WriteLine("Enter Weekly Students Schedule End Time: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                DateTime EndTime;
                DateTime.TryParse(Console.ReadLine(), out EndTime);
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.WriteLine("Enter Weekly Students Schedule Teacher: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string teacher = Console.ReadLine();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.WriteLine("Enter Weekly Students Schedule ClassRoom: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string ClassRoom = Console.ReadLine();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                WeeklyStudentSchedule.Add($"{day}: {moduleName} {courseName} {DebutTime} {EndTime} {teacher} {ClassRoom}");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                Console.ResetColor();
            }
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            WeeklyStudentSchedule.Add(className);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nWeekly Students Schedule Added Successfully!\n");
            Console.ResetColor();
        }

        private static void ManageTeacherSchedule()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************************\n");
            Console.WriteLine("            Manage Weekly Teachers Schedule             ");
            Console.WriteLine("\n*****************************************************\n");
            Console.WriteLine("Enter Weekly Teachers Schedule Class: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string className = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            foreach (var day in WeekDays)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Enter Weekly Teachers Schedule Details for {day}: ");
                Console.WriteLine("\n");
                Console.WriteLine("Enter Weekly Teachers Schedule Module: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string moduleName = Console.ReadLine();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.WriteLine("Enter Weekly Teachers Schedule Course: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string courseName = Console.ReadLine();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.WriteLine("Enter Weekly Teachers Schedule Debut Time: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                DateTime DebutTime;
                DateTime.TryParse(Console.ReadLine(), out DebutTime);
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.WriteLine("Enter Weekly Teachers Schedule End Time: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                DateTime EndTime;
                DateTime.TryParse(Console.ReadLine(), out EndTime);
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.WriteLine("Enter Weekly Teachers Schedule Teacher: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string teacher = Console.ReadLine();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.WriteLine("Enter Weekly Teachers Schedule ClassRoom: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string ClassRoom = Console.ReadLine();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                WeeklyTeacherSchedule.Add($"{day}: {moduleName} {courseName} {DebutTime} {EndTime} {teacher} {ClassRoom}");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                Console.ResetColor();
            }
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            WeeklyTeacherSchedule.Add(className);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nWeekly Teachers Schedule Added Successfully!\n");
            Console.ResetColor();
        }

         public static void ViewSchedule()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("            View  Weekly Shedule             ");
            Console.WriteLine("\n****************************************\n");
            Console.WriteLine("1. View Weekly Students Shedule\n");
            Console.WriteLine("2. View Weekly Teachers Shedule\n");
            Console.WriteLine("3. Back To Calendar and Schedule Menu\n");
            Console.ResetColor();
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    ViewStudentSchedule();
                    break;

                case 2:
                    ViewTeacherShedule();
                    break;

                case 3:
                    return; // Return to the Calendar and Schedule menu

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }
        }

        public static void ViewStudentSchedule()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("         View Weekly Student Schedule       ");
            Console.WriteLine("\n***************************************\n");
            Console.ResetColor();
            Console.Write("Enter student Class: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string cclass = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Student student = Student.students.Find(s => s.Class == cclass);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            List<string> weeklySchedule = WeeklyStudentSchedule;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (weeklySchedule != null && weeklySchedule.Count > 0)
            {
                    Console.ForegroundColor = ConsoleColor.Green;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                Console.WriteLine($"Students Class: {student.Class}\n");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                Console.WriteLine("\nWeekly Schedule:\n");

                    foreach (var daySchedule in weeklySchedule)
                    {
                        Console.WriteLine(daySchedule);
                    }
                Console.ResetColor();
                Console.WriteLine("\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No schedule available for this Class.\n");
                Console.ResetColor();
            }
        }

         public static void ViewTeacherShedule()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("          View weekly Teacher Shedule:              ");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.WriteLine("Enter teacher ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Teacher teacherToView = Teacher.teachers.Find(t => t.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            List<string> weeklySchedule = WeeklyTeacherSchedule;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (weeklySchedule != null && weeklySchedule.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                Console.WriteLine($"Teacher Full Name: {teacherToView.FirstName} {teacherToView.LastName}");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                Console.WriteLine("\n");
                Console.WriteLine("Weekly Schedule: ");
                Console.WriteLine("\n");
                foreach (var daySchedule in weeklySchedule)
                {
                    Console.WriteLine(daySchedule);
                }
                Console.ResetColor();
                Console.WriteLine("\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No schedule available for this teacher.\n");
                Console.ResetColor();
            }
        }

        public static void ViewCalendar()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("            View Calendar             ");
            Console.WriteLine("\n****************************************\n");
            Console.WriteLine("1. View Exam Dates and Deadlines\n");
            Console.WriteLine("2. View Upcoming Modules and Courses\n");
            Console.WriteLine("3. Back To Calendar and Schedule Menu\n");
            Console.ResetColor();
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    ViewExamDatesAndDeadlines();
                    break;

                case 2:
                    ViewUpcomingModulesAndCourses();
                    break;

                case 3:
                    return; // Return to the Calendar and Schedule menu

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }
        }

        private static void ManageCalender()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("            Manage Calendar             ");
            Console.WriteLine("\n****************************************\n");
            Console.WriteLine("1. Manage Exam Dates and Deadlines\n");
            Console.WriteLine("2. Manage Upcoming Modules and Courses\n");
            Console.WriteLine("3. Back To Calendar and Schedule Menu\n");
            Console.ResetColor();
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    ManageExamDatesAndDeadlines();
                    break;

                case 2:
                    ManageUpcomingModulesAndCourses();
                    break;

                case 3:
                    return; // Return to the Calendar and Schedule menu

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }
        }

        private static void ManageExamDatesAndDeadlines()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************************\n");
            Console.WriteLine("               Manage Exam Dates and Deadlines          ");
            Console.WriteLine("\n****************************************************\n");
            Console.WriteLine("Enter Class Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string className = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.WriteLine("Enter Module Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string moduleName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
          Console.WriteLine("\n");
            Console.WriteLine("Enter Course Name: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string courseName = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.WriteLine("Enter Exam Date: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            DateTime examDate = Convert.ToDateTime(Console.ReadLine());
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.WriteLine("Enter Project Deadline: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            DateTime projectDeadline = Convert.ToDateTime(Console.ReadLine());
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            ExamsDatesAndDeadlines.Add(new Administrator(null, null, null, 0, 0, null, null, DateTime.Now, null, null, className, moduleName, courseName, examDate, projectDeadline));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nExam Date and Deadline added successfully!\n");
            Console.ResetColor();
        }

        private static void ManageUpcomingModulesAndCourses()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("            View Upcoming Modules and Courses  ");
            Console.WriteLine("\n****************************************\n");
            Console.WriteLine("Enter Class Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string className = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.WriteLine("Enter Upcoming Module Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string upcomingModuleName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.WriteLine("Enter Upcoming Course Name: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string upcomingCourseName = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.WriteLine("Enter Upcoming Course Debut Date: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            DateTime upcomingCourseDebutDate = Convert.ToDateTime(Console.ReadLine());
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.WriteLine("Enter Upcoming Course End Date: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            DateTime upcomingCourseEndDate = Convert.ToDateTime(Console.ReadLine());
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.WriteLine("Enter Course Teacher Name: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string courseTeacherName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            UpcomingModulesAndCourses.Add(new Administrator(null, null, null, 0, 0, null, null, DateTime.Now, null, null, className, upcomingModuleName, upcomingCourseName, upcomingCourseDebutDate, upcomingCourseEndDate));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nUpcoming Module and Course added successfully!\n");
            Console.ResetColor();
        }
            

        public static void ViewExamDatesAndDeadlines()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("******************************************\n");
            Console.WriteLine("        View Exam Dates and Deadlines       ");
            Console.WriteLine("\n****************************************\n");
            Console.ResetColor();

            foreach (var examDate in ExamsDatesAndDeadlines)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Class Name: " + examDate.ClassName, "Module Name: " + examDate.ModuleName, "Course Name: " + examDate.CourseName, "Exam Date: " + examDate.ExamDate, "Project Deadline: " + examDate.ProjectDeadLine + "\n");
                Console.ResetColor();
            } 
        }

        public static void ViewUpcomingModulesAndCourses()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**********************************************\n");
            Console.WriteLine("        View Upcoming Modules and Courses       ");
            Console.WriteLine("\n********************************************\n");
            Console.ResetColor();

            foreach (var upcomingModuleAndCourse in UpcomingModulesAndCourses)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Class Name: " + upcomingModuleAndCourse.ClassName);
                Console.WriteLine("Upcoming Module Name: " + upcomingModuleAndCourse.ModuleName);
                Console.WriteLine("Upcoming Course Name: " + upcomingModuleAndCourse.CourseName);
                Console.WriteLine("Upcoming Course Debut Date: " + upcomingModuleAndCourse.ExamDate);
                Console.WriteLine("Upcoming Course End Date: " + upcomingModuleAndCourse.ProjectDeadLine);
                Console.WriteLine("Course Teacher Name: " + upcomingModuleAndCourse.ProjectDeadLine + "\n");
                Console.ResetColor();
            }
        }


        private static void GenerateReports()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("            Generate Reports             ");
            Console.WriteLine("\n****************************************\n");
            Console.WriteLine("1. Generate Student Performance Report\n");
            Console.WriteLine("2. Generate Teacher Performance Report\n");
            Console.WriteLine("3. Back to Admin Menu");
            Console.ResetColor();
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    StudentPerformanceReport();
                    break;

                case 2:
                    TeacherPerformanceReport();
                    break;

                case 3:
                    return; // Return to the admin menu

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }
        }

        private static void StudentPerformanceReport() // You can use students list and their properties for generating the report
                                                                    
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**********************************************************\n");
            Console.WriteLine("            Student Performance Report             ");
            Console.WriteLine("\n**********************************************************\n");
            Console.WriteLine("1. View Students List\n");
            Console.WriteLine("2. Generate Student Performance Report\n");
            Console.WriteLine("3. Dispay Student Performance Report\n");
            Console.WriteLine("4. Back to Generate Report Menu\n");
            Console.ResetColor();
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Student.ViewStudents();
                    break;

                case 2:
                    GenerateStudentPerformanceReport();
                    break;

                case 3:
                    ViewStudentPerformanceReport();
                    break;

                case 4:
                    return; // Return to the generate reports menu

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }
        }

        
        private static void GenerateStudentPerformanceReport()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**********************************************************\n");
            Console.WriteLine("            Generate Student Performance Report             ");
            Console.WriteLine("\n********************************************************\n");
            Console.ResetColor();
            Console.WriteLine("Enter Student ID: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            int studentID = Convert.ToInt32(Console.ReadLine());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Student student = Student.students.Find(student => student.Id == studentID);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (student != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Student Full Name: " + student.FirstName + " " + student.LastName + "Registred in : " + student.Class + "\n");
                Console.ResetColor();
                Console.WriteLine("Enter The Student Performance Report: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string studentPerformanceReport = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                StudentPerformanceReports.Add(new Administrator(null, null, null, 0, 0, null, null, DateTime.Now, null, null, null, null, null, DateTime.Now, DateTime.Now));           
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nStudent Performance Report added successfully!\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student not found!\n");
                Console.ResetColor();
                
            }
        }

        private static void ViewStudentPerformanceReport()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**********************************************************\n");
            Console.WriteLine("            View Student Performance Report             ");
            Console.WriteLine("\n********************************************************\n");
            Console.ResetColor();
            Console.WriteLine("Enter Student ID: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            int studentID = Convert.ToInt32(Console.ReadLine());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Student student = Student.students.Find(student => student.Id == studentID);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (student != null)
            {
                foreach (var studentPerformanceReport in StudentPerformanceReports)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Student Full Name: " + student.FirstName + " " + student.LastName + "Registred in : " + student.Class + "\n");
                    Console.WriteLine("Student Performance Report: " + studentPerformanceReport + "\n");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student not found!\n");
                Console.ResetColor();
            }
        }

        private static void TeacherPerformanceReport()             // Implement logic to generate and display teacher performance report
                                                                    // You can use teachers list and their properties for generating the report
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**********************************************************\n");
            Console.WriteLine("            Teacher Performance Report             ");
            Console.WriteLine("\n**********************************************************\n");
            Console.WriteLine("1. View Teachers List\n");
            Console.WriteLine("2. Generate Teacher Performance Report\n");
            Console.WriteLine("3. Dispay Teacher Performance Report\n");
            Console.WriteLine("4. Back to Generate Report Menu\n");
            Console.ResetColor();
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Teacher.ViewTeachers();
                    break;

                case 2:
                    GenerateTeacherPerformanceReport();
                    break;

                case 3:
                    ViewTeacherPerformanceReport();
                    break;

                case 4:
                    return; // Return to the generate reports menu

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }
        }

        private static void GenerateTeacherPerformanceReport()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**********************************************************\n");
            Console.WriteLine("            Generate Teacher Performance Report             ");
            Console.WriteLine("\n********************************************************\n");
            Console.ResetColor();
            Console.WriteLine("Enter Teacher ID: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            int teacherID = Convert.ToInt32(Console.ReadLine());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Teacher teacher = Teacher.teachers.Find(teacher => teacher.Id == teacherID);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (teacher != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teacher Full Name: " + teacher.FirstName + " " + teacher.LastName + "Course Assigned : " + teacher.AssignedCourse + "\n");
                Console.ResetColor();
                Console.WriteLine("Enter The Teacher Performance Report: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string teacherPerformanceReport = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                TeacherPerformanceReports.Add(new Administrator(null, null, null, 0, 0, null, null, DateTime.Now, null, null, null, null, null, DateTime.Now, DateTime.Now));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nTeacher Performance Report added successfully!\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Teacher not found!\n");
                Console.ResetColor();
            }
        }

        private static void ViewTeacherPerformanceReport()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**********************************************************\n");
            Console.WriteLine("            View Teacher Performance Report             ");
            Console.WriteLine("\n********************************************************\n");
            Console.ResetColor();
            Console.WriteLine("Enter Teacher ID: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            int teacherID = Convert.ToInt32(Console.ReadLine());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Teacher teacher = Teacher.teachers.Find(teacher => teacher.Id == teacherID);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (teacher != null)
            {
                foreach (var teacherPerformanceReport in TeacherPerformanceReports)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Teacher Full Name: " + teacher.FirstName + " " + teacher.LastName + "Course Assigned : " + teacher.AssignedCourse + "\n");
                    Console.WriteLine("Teacher Performance Report: " + teacherPerformanceReport + "\n");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Teacher not found!\n");
                Console.ResetColor();
            }
        }

        private static void SystemSettings()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("              System Settings                ");
            Console.WriteLine("\n****************************************\n");
            Console.WriteLine("1. Configure System Parameters\n");
            Console.WriteLine("2. Configure Email Notifications\n");
            Console.WriteLine("3. Back to Admin Menu\n");
            Console.ResetColor();
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    ConfigureSystemParameters();
                    break;

                case 2:
                    ConfigureEmailNotifications();
                    break;

                case 3:
                    return; // Return to the admin menu

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }
        }

        private static void ConfigureSystemParameters()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**************************************************\n");
            Console.WriteLine("            Configure System Parameters             ");
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("1. Configure System Language\n");
            Console.WriteLine("2. Configure System Time Zone\n");
            Console.WriteLine("3. Back to System Settings Menu\n");
            Console.ResetColor();
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    ConfigureSystemLanguage();
                    break;

                case 2:
                    ConfigureSystemTimeZone();
                    break;

                case 4:
                    return; // Return to the system settings menu

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }

        }

        private static void ConfigureSystemLanguage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**************************************************\n");
            Console.WriteLine("            Configure System Language             ");
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("1. English\n");
            Console.WriteLine("2. French\n");
            Console.WriteLine("3. Spanish\n");
            Console.WriteLine("4. Back to System Settings Menu\n");
            Console.ResetColor();
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("System language changed to English!\n");
                    Console.ResetColor();
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("System language changed to French!\n");
                    Console.ResetColor();
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("System language changed to Spanish!\n");
                    Console.ResetColor();
                    break;

                case 4:
                    return; // Return to the configure system parameters menu

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }
        }

        private static void ConfigureSystemTimeZone()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**************************************************\n");
            Console.WriteLine("            Configure System Time Zone             ");
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("1. GMT\n");
            Console.WriteLine("2. UTC\n");
            Console.WriteLine("3. EST\n");
            Console.WriteLine("4. Back to System Settings Menu\n");
            Console.ResetColor();
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("System time zone changed to GMT!\n");
                    Console.ResetColor();
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("System time zone changed to UTC!\n");
                    Console.ResetColor();
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("System time zone changed to EST!\n");
                    Console.ResetColor();
                    break;

                case 4:
                    return; // Return to the configure system parameters menu

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }
        }

        private static void ConfigureEmailNotifications()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**************************************************\n");
            Console.WriteLine("            Configure Email Notifications             ");
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("1. Enable Email Notifications\n");
            Console.WriteLine("2. Disable Email Notifications\n");
            Console.WriteLine("3. Back to System Settings Menu\n");
            Console.ResetColor();
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Email notifications enabled!\n");
                    Console.ResetColor();
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Email notifications disabled!\n");
                    Console.ResetColor();
                    break;

                case 3:
                    return; // Return to the configure system parameters menu

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
