using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.SymbolStore;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Newtonsoft.Json;
using System.Data.Common;

namespace SCHOOL_MANAGEMENT_CONSOLE_APP
{
    class Administrator : Person // Inherit from Person class
    {
        // Properties
        public string Grade { get; set; }
        public string? ClassName { get; set; }
        public string? ModuleName { get; set; }
        public string? CourseName { get; set; }
        public DateTime UpcomingCourseDebutTime { get; set; }
        public DateTime UpComingCourseEndTime { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime ProjectDeadLine { get; set; }
        public string? CourseTeacherName { get; set; }
        public DateTime StudentPerformanceReportDate { get; set; }
        public string? StudentPerformanceReportText { get; set; }
        public DateTime TeacherPerformanceReportDate { get; set; }
        public string? TeacherPerformanceReportText { get; set; }
        public static string? SymLanguageType { get; private set; }

        //Lists
        public static List<string> weekDays = new() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public static List<string>? WeeklyTeacherSchedule { get; set; }
        public static List<string>? WeeklyStudentSchedule { get; set; }
        public static List<Administrator> administrators = new();
        public static List<Administrator> examsDatesAndDeadlines = new();
        public static List<Administrator> upcomingModulesAndCourses = new();
        public static List<Administrator> studentPerformanceReportsList = new();
        public static List<Administrator> teacherPerformanceReportsList = new();

        // Constructor
        public Administrator(string firstName, string lastName, string gender, int id, int phoneNumber, string email, string address, DateTime dateOfBirth, string nationality, string grade, string? className, string? moduleName, string? courseName, DateTime upComingDebutTime, DateTime upComingEndTime, DateTime examDate, DateTime projectDeadline, string courseTeacherName, DateTime studentPerformanceReportDate, string? studentPerformanceReportText, DateTime teacherPerformanceReportDate, string? teacherPerformanceReportText) : base(firstName, lastName, gender, id, phoneNumber, email, address, dateOfBirth, nationality)
        {
            Grade = grade;
            ClassName = className;
            ModuleName = moduleName;
            CourseName = courseName;
            UpcomingCourseDebutTime = upComingDebutTime;
            UpComingCourseEndTime = upComingEndTime;
            ExamDate = examDate;
            ProjectDeadLine = projectDeadline;
            CourseTeacherName = courseTeacherName;
            StudentPerformanceReportDate = studentPerformanceReportDate;
            StudentPerformanceReportText = studentPerformanceReportText;
            TeacherPerformanceReportDate = teacherPerformanceReportDate;
            TeacherPerformanceReportText = teacherPerformanceReportText;
        }

        public static void ManageAdministration()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n==================================================\n");
                Console.WriteLine("                 Manage Administration");
                Console.WriteLine("\n==================================================\n");
                Console.WriteLine("1. Manage Students < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("2. Manage Teachers < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("3. Manage Modules < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("4. Manage Courses < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("5. Manage Admininstrator < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("6. Calendar and Schedule < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("7. Generate Reports < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("8. System Settings < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("9. Back to main menu\n");
                Console.ResetColor(); // Reset color to default
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

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
                        ManageAdministrator();
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
                        Program.MainMenu();
                        break; // Return to the main menu

                    default:
                        Console.WriteLine("Invalid choice. Try again.\n");
                        break;
                }
                
            } while (true); // Infinite loop to keep the user in the menu
        }

        private static void ManageAdministrator()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("******************************************************\n");
                Console.WriteLine("              Administrator Management System          ");
                Console.WriteLine("\n****************************************************\n");
                Console.WriteLine("1. Add Administrator\n");
                Console.WriteLine("2. Display Administrator Details\n");
                Console.WriteLine("3. View Administrators List\n");
                Console.WriteLine("4. Update Administrator\n");
                Console.WriteLine("5. Delete Administrator\n");
                Console.WriteLine("6. Back to Admin Menu\n");
                Console.ResetColor();
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddAdministrator();
                        break;

                    case 2:
                        DisplayAdministratorDetails();
                        break;

                    case 3:
                        ViewAdministratorsList();
                        break;

                    case 4:
                        UpdateAdministrator();
                        break;

                    case 5:
                        DeleteAdministrator();
                        break;

                    case 6:
                        return; // Return to the admin menu

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Infinite loop to keep the user in the menu
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
            Console.Write("");
            Console.Write("Enter Administrator Last Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string lastName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("Enter Administrtor Gender : ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string gender = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.Write("");
            Console.Write("Enter Administrator ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("");
            Console.Write("Enter Administrator Phone Number: ");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("");
            Console.Write("Enter Administrator Email: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string email = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.Write("");
            Console.Write("Enter Administrator Address: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string address = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.Write("");
            Console.Write("Enter Administrator Birth Date: ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.Write("");
            Console.Write("Enter Administrator Nationality: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string nationality = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.Write("");
            Console.WriteLine("Enter Administrator Grade: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string grade = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Administrator newAdmin = new(firstName, lastName, gender, id, phoneNumber, email, address, dateOfBirth, nationality, grade, null, null, null, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, null, DateTime.Now, null, DateTime.Now, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8604 // Possible null reference argument.
            administrators.Add(newAdmin);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Administrator added successfully !");
            Console.ResetColor();
            Console.WriteLine(""); 
            // Save Admin to the json file
            SaveAdministratorsToJson();
            Console.WriteLine("");
        }

        private static void DisplayAdministratorDetails()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("            View Administrator Details            ");
            Console.WriteLine("\n****************************************\n");
            Console.Write("Enter Administrator ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            // Upload Admins from the json file
            LoadAdminsFromJson();
            Console.WriteLine("");
            // Find the admin by id
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Administrator adminToDislayDetails = administrators.Find(admin => admin.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (adminToDislayDetails != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Administrator  ID: {adminToDislayDetails.Id} \t Administrator Full Name: {adminToDislayDetails.FirstName + " "} {adminToDislayDetails.LastName} \t  Administrator Gender : {adminToDislayDetails.Gender} \t Administrator Email : {adminToDislayDetails.Email} \t Admininstrator Phone Number : {adminToDislayDetails.PhoneNumber} \t Administrator Address : {adminToDislayDetails.Address} \t Admininstrator Birth Date : {adminToDislayDetails.DateOfBirth} \t AddAdministrator Nationality : {adminToDislayDetails.Nationality} \t Administrator Grade : {adminToDislayDetails.Grade}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Administrator not found.\n");
                Console.ResetColor();
            }
        }

        private static void ViewAdministratorsList()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**********************************************\n");
            Console.WriteLine("            View Administrators List            ");
            Console.WriteLine("\n*********************************************\n");
            Console.ResetColor();
            // Upload Admins from the json file
            LoadAdminsFromJson();
            Console.WriteLine("");
            foreach (var admin in administrators)
            {
                if (administrators.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No administrators found !");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Administrator N`{0} ", administrators.IndexOf(admin) + 1);
                    Console.WriteLine($"Administrator ID : {admin.Id} \t Administrator Full Name : {admin.FirstName + " "} {admin.LastName}");
                    Console.ResetColor();

                }
            }
        }

        private static void UpdateAdministrator()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("            Update Administrator             ");
            Console.WriteLine("\n****************************************\n");
            Console.Write("Enter Administrator ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Administrator adminToUpdate = administrators.Find(admin => admin.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (adminToUpdate != null)
            {
                Console.Write("Enter New Administrator First Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string firstName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.Write("");
                Console.Write("Enter New Administrator Last Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string lastName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("");
                Console.WriteLine("Enter New Administrator Gender : ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string gender = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.Write("");
                Console.Write("Enter New Administrator ID: ");
                int newId = Convert.ToInt32(Console.ReadLine());
                Console.Write("");
                Console.Write("Enter New Administrator Phone Number: ");
                int phoneNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("");
                Console.Write("Enter New Administrator Email: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string email = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.Write("");
                Console.Write("Enter New Administrator Address: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string address = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.Write("");
                Console.Write("Enter New Administrator Date of Birth: ");
                DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
                Console.Write("");
                Console.WriteLine("Enter New Administrator Nationality: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string nationality = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.Write("");
                Console.WriteLine("Enter New Administrator Grade: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string grade = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8601 // Possible null reference assignment.
                adminToUpdate.FirstName = firstName;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                adminToUpdate.LastName = lastName;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                adminToUpdate.Gender = gender;
#pragma warning restore CS8601 // Possible null reference assignment.
                adminToUpdate.Id = newId;
                adminToUpdate.PhoneNumber = phoneNumber;
#pragma warning disable CS8601 // Possible null reference assignment.
                adminToUpdate.Email = email;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                adminToUpdate.Address = address;
#pragma warning restore CS8601 // Possible null reference assignment.
                adminToUpdate.DateOfBirth = dateOfBirth;
#pragma warning disable CS8601 // Possible null reference assignment.
                adminToUpdate.Nationality = nationality;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                adminToUpdate.Grade = grade;
#pragma warning restore CS8601 // Possible null reference assignment.
                administrators.Add(adminToUpdate);  // Add the updated admin to the list
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Administrator updated successfully !");
                Console.ResetColor();
                Console.WriteLine("");
                // Save Admin to the json file
                SaveAdministratorsToJson();
                Console.WriteLine("");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Administrator not found.\n");
                Console.ResetColor();
            }
        }

        private static void DeleteAdministrator()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("            Delete Administrator             ");
            Console.WriteLine("\n****************************************\n");
            Console.Write("Enter Administrator ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Administrator adminToDelete = administrators.Find(admin => admin.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (adminToDelete != null)
            {
                administrators.Remove(adminToDelete);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Administrator deleted successfully !");
                Console.ResetColor();
                Console.WriteLine("");
                // Save Admin to the json file
                SaveAdministratorsToJson();
                Console.WriteLine("");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Administrator not found.\n");
                Console.ResetColor();
            }
        }
        
        private static void CalendarAndSchedule()
        {
            do
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
                        ManageAdministration(); // Return to the admin menu
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Infinite loop to keep the user in the menu
        }

        private static void ManageWeeklySchedule()
        {
            do
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
                        CalendarAndSchedule(); // Return to the Calendar and Schedule menu
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Infinite loop to keep the user in the menu
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
            Console.WriteLine("");
            foreach (var day in weekDays)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Enter Weekly Students Schedule Details for {day}: ");
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Students Schedule Module: ");  
    #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string moduleName = Console.ReadLine();
    #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Students Schedule Course: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string courseName = Console.ReadLine();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Students Schedule Debut Time: ");
                _ = DateTime.TryParse(Console.ReadLine(), out DateTime debutTime);
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Students Schedule End Time: ");
                _ = DateTime.TryParse(Console.ReadLine(), out DateTime endTime);
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Students Schedule Teacher: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string teacher = Console.ReadLine();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Students Schedule ClassRoom: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string classRoom = Console.ReadLine();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                WeeklyStudentSchedule.Add($"{day}: {moduleName} {courseName} {debutTime} {endTime} {teacher} {classRoom}");
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
            // Save Student to the json file
            SaveStudentWeeklyScheduleToJson();
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
            Console.WriteLine("");
            foreach (var day in weekDays)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Enter Weekly Teachers Schedule Details for {day}: ");
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Teachers Schedule Module: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string moduleName = Console.ReadLine();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Teachers Schedule Course: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string courseName = Console.ReadLine();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Teachers Schedule Debut Time: ");
                _ = DateTime.TryParse(Console.ReadLine(), out DateTime debutTime);
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Teachers Schedule End Time: ");
                _ = DateTime.TryParse(Console.ReadLine(), out DateTime endTime);
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Teachers Schedule Teacher: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string teacher = Console.ReadLine();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("");
                Console.WriteLine("Enter Weekly Teachers Schedule ClassRoom: ");
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string ClassRoom = Console.ReadLine();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                WeeklyTeacherSchedule.Add($"{day}: {moduleName} {courseName} {debutTime} {endTime} {teacher} {ClassRoom}");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                Console.ResetColor();
            }
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            WeeklyTeacherSchedule.Add(className);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Weekly Teachers Schedule Added Successfully !");
            // Save Teacher to the json file
            SaveTeacherWeeklyScheduleToJson();
            Console.ResetColor();
        }

        public static void ViewSchedule()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("*****************************************\n");
                Console.WriteLine("            View  Weekly Schedule             ");
                Console.WriteLine("\n****************************************\n");
                Console.WriteLine("1. View Weekly Students Schedule\n");
                Console.WriteLine("2. View Weekly Teachers Schedule\n");
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
                        ViewTeacherSchedule();
                        break;

                    case 3:
                        CalendarAndSchedule(); // Return to the Calendar and Schedule menu
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Infinite loop to keep the user in the menu
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
            Console.WriteLine("");
            // Upload Students from the json file
            LoadStudentWeeklyScheduleFromJson();
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
                Console.WriteLine("");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No schedule available for this Class.\n");
                Console.ResetColor();
            }
        }

         public static void ViewTeacherSchedule()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("          View weekly Teacher Schedule:              ");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter teacher ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            // Upload Teachers from the json file
            LoadTeacherWeeklyScheduleFromJson();
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
                Console.WriteLine($"Teacher Full Name: {teacherToView.FirstName} {teacherToView.LastName}\n");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                Console.WriteLine("Weekly Schedule: ");
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
                Console.WriteLine("No schedule available for this teacher.");
                Console.ResetColor();
            }
        }

        public static void ViewCalendar()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n*****************************************\n");
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
                        CalendarAndSchedule(); // Return to the Calendar and Schedule menu
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Infinite loop to keep the user in the menu 
        }

        private static void ManageCalender()
        {
            do
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
                        CalendarAndSchedule(); // Return to the Calendar and Schedule menu
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Infinite loop to keep the user in the menu
        }

        private static void ManageExamDatesAndDeadlines()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************************\n");
            Console.WriteLine("               Manage Exam Dates and Deadlines          ");
            Console.WriteLine("\n****************************************************\n");
            Console.Write("Enter Class Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string className = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.Write("Enter Module Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string moduleName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.Write("Enter Course Name: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string courseName = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.Write("Enter Exam Date: ");
            DateTime examDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Enter Project Deadline: ");
            DateTime projectDeadline = Convert.ToDateTime(Console.ReadLine());
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            examsDatesAndDeadlines.Add(new Administrator(null, null, null, 0, 0, null, null, DateTime.Now, null, null, className, moduleName, courseName, DateTime.Now, DateTime.Now, examDate, projectDeadline, null, DateTime.Now, null, DateTime.Now, null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Exam Date and Deadline added successfully !");
            // Save Exam Date and Deadline to the json file
            SaveExamsDatesAndDeadlinesToJson();
            Console.ResetColor();
        }

        private static void ManageUpcomingModulesAndCourses()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************************************************\n");
            Console.WriteLine("            View Upcoming Modules and Courses          ");
            Console.WriteLine("\n***************************************************\n");
            Console.WriteLine("Enter Class Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string className = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.WriteLine("Enter Upcoming Module Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string upcomingModuleName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.WriteLine("Enter Upcoming Course Name: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string upcomingCourseName = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.WriteLine("Enter Upcoming Course Debut Date: ");
            DateTime upcomingCourseDebutDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Enter Upcoming Course End Date: ");
            DateTime upcomingCourseEndDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Enter Course Teacher Name: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string courseTeacherName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8604 // Possible null reference argument.
            upcomingModulesAndCourses.Add(new Administrator(null, null, null, 0, 0, null, null, DateTime.Now, null, null, className, upcomingModuleName, upcomingCourseName, upcomingCourseDebutDate, upcomingCourseEndDate, DateTime.Now, DateTime.Now, courseTeacherName, DateTime.Now, null, DateTime.Now, null));
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Upcoming Module and Course added successfully !");
            // Save Upcoming Module and Course to the json file
            SaveUpcomingModulesAndCoursesToJson();
            Console.ResetColor();
        }
            

        public static void ViewExamDatesAndDeadlines()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("******************************************\n");
            Console.WriteLine("        View Exam Dates and Deadlines       ");
            Console.WriteLine("\n****************************************\n");
            Console.ResetColor();
            Console.Write("Enter Class Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string className = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            // Upload Exam Dates and Deadlines from the json file
            LoadExamsDatesAndDeadlinesFromJson();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Administrator examDateToView = examsDatesAndDeadlines.Find(examDate => examDate.ClassName == className);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (examDateToView != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Class Name: " + examDateToView.ClassName);
                Console.WriteLine("Module Name: " + examDateToView.ModuleName);
                Console.WriteLine("Course Name: " + examDateToView.CourseName);
                Console.WriteLine("Exam Date: " + examDateToView.ExamDate);
                Console.WriteLine("Project Deadline: " + examDateToView.ProjectDeadLine + "\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exam Date and Deadline not found !\n");
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
            Console.Write("Enter Class Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string className = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            // Upload Upcoming Modules and Courses from the json file
            LoadUpcomingModulesAndCoursesFromJson();
            Administrator upcomingModuleAndCourseToView = upcomingModulesAndCourses.Find(upcomingModuleAndCourse => upcomingModuleAndCourse.ClassName == className);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (upcomingModuleAndCourseToView != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Class Name: " + upcomingModuleAndCourseToView.ClassName);
                Console.WriteLine("Upcoming Module Name: " + upcomingModuleAndCourseToView.ModuleName);
                Console.WriteLine("Upcoming Course Name: " + upcomingModuleAndCourseToView.CourseName);
                Console.WriteLine("Upcoming Course Debut Date: " + upcomingModuleAndCourseToView.UpcomingCourseDebutTime);
                Console.WriteLine("Upcoming Course End Date: " + upcomingModuleAndCourseToView.UpComingCourseEndTime);
                Console.WriteLine("Course Teacher Name: " + upcomingModuleAndCourseToView.CourseTeacherName + "\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Upcoming Module and Course not found !\n");
                Console.ResetColor();
            }
        }


        private static void GenerateReports()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("*****************************************\n");
                Console.WriteLine("            Generate Reports             ");
                Console.WriteLine("\n****************************************\n");
                Console.WriteLine("1. Generate Student Performance Report\n");
                Console.WriteLine("2. Generate Teacher Performance Report\n");
                Console.WriteLine("3. Back to Admin Menu\n");
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
                        ManageAdministration(); // Return to the admin menu
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Infinite loop Until the user choose to return to the admin menu
        }

        private static void StudentPerformanceReport() // You can use students list and their properties for generating the report                                                          
        {
            do
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
                        GenerateReports(); // Return to the generate reports menu
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Infinite loop Until the user choose to return to the generate reports menu
        }

        
        private static void GenerateStudentPerformanceReport()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**********************************************************\n");
            Console.WriteLine("            Generate Student Performance Report             ");
            Console.WriteLine("\n********************************************************\n");
            Console.ResetColor();
            Console.WriteLine("Enter Student ID: ");
            int studentID = Convert.ToInt32(Console.ReadLine());
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Student student = Student.students.Find(student => student.Id == studentID);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (student != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Student Full Name: " + student.FirstName + " " + student.LastName + "Registred in : " + student.Class + "\n");
                Console.ResetColor();
                Console.Write("Enter The Student Performance Report Date: ");
                DateTime studentPerformanceReportDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("");
                Console.WriteLine("Enter The Student Performance Report: ");
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string studentPerformanceReportText = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                studentPerformanceReportsList.Add(new Administrator(null, null, null, 0, 0, null, null, DateTime.Now, null, null, null, null, null, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, null, studentPerformanceReportDate, studentPerformanceReportText, DateTime.Now, null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nStudent Performance Report added successfully !");
                // Save Student Performance Report to the json file
                SaveStudentPerformanceReportsToJson();
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
            Console.Write("Enter Student ID: ");
            int studentID = Convert.ToInt32(Console.ReadLine());
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            // Upload Student Performance Reports from the json file
            LoadStudentPerformanceReportsFromJson();
            Student student = Student.students.Find(student => student.Id == studentID);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (student != null)
            {
                foreach (var studentPerformanceReport in studentPerformanceReportsList)
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

        private static void TeacherPerformanceReport()             
        {
            do 
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
                        GenerateReports();  // Return to the generate reports menu
                        break; 

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Infinite loop Until the user choose to return to the generate reports menu
        }

        private static void GenerateTeacherPerformanceReport()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**********************************************************\n");
            Console.WriteLine("            Generate Teacher Performance Report             ");
            Console.WriteLine("\n********************************************************\n");
            Console.ResetColor();
            Console.Write("Enter Teacher ID: ");
            int teacherID = Convert.ToInt32(Console.ReadLine());
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Teacher teacher = Teacher.teachers.Find(teacher => teacher.Id == teacherID);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (teacher != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teacher Full Name: " + teacher.FirstName + " " + teacher.LastName + "Course Assigned : " + teacher.AssignedCourse + "\n");
                Console.ResetColor();
                Console.WriteLine("Enter The Teacher Performance Report Date: ");
                DateTime teacherPerformanceReportDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("");
                Console.WriteLine("Enter The Teacher Performance Report: ");
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string teacherPerformanceReportText = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                teacherPerformanceReportsList.Add(new Administrator(null, null, null, 0, 0, null, null, DateTime.Now, null, null, null, null, null, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, null, DateTime.Now, null, teacherPerformanceReportDate, teacherPerformanceReportText));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nTeacher Performance Report added successfully !");
                // Save Teacher Performance Report to the json file
                SaveTeacherPerformanceReportsToJson();
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
            Console.Write("Enter Teacher ID: ");
            int teacherID = Convert.ToInt32(Console.ReadLine());
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            // Upload Teacher Performance Reports from the json file
            LoadTeacherPerformanceReportsFromJson();
            Teacher teacher = Teacher.teachers.Find(teacher => teacher.Id == teacherID);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (teacher != null)
            {
                foreach (var teacherPerformanceReport in teacherPerformanceReportsList)
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
            do
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
                        ManageAdministration(); // Return to the admin menu
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Infinite loop Until the user choose to return to the admin menu
        }

        private static void ConfigureSystemParameters()
        {
            do
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

                    case 3:
                        SystemSettings(); // Return to the system settings menu
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Infinite loop Until the user choose to return to the system settings menu
        }

        private static void ConfigureSystemLanguage()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("**************************************************\n");
                Console.WriteLine("            Configure System Language             ");
                Console.WriteLine("\n************************************************\n");
                Console.WriteLine("1. English\n");
                Console.WriteLine("2. French\n");
                Console.WriteLine("3. Spanish\n");
                Console.WriteLine("4. Arabic\n");
                Console.WriteLine("5. Back to System Settings Menu\n");
                Console.ResetColor();
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        SymLanguageType = "en-US";
                        Console.WriteLine("System language changed to English!\n");
                        Console.ResetColor();
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        SymLanguageType = "fr-FR";
                        Console.WriteLine("System language changed to French!\n");
                        Console.ResetColor();
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        SymLanguageType = "es-ES";
                        Console.WriteLine("System language changed to Spanish!\n");
                        Console.ResetColor();
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        SymLanguageType = "ar-AR";
                        Console.WriteLine("System language changed to Arabic!\n");
                        Console.ResetColor();
                        break;

                    case 5:
                        SystemSettings(); // Return to the configure system parameters menu
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Infinite loop Until the user choose to return to the system settings menu
        }

        private static void ConfigureSystemTimeZone()
        {
            do
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
                        var timeNow = DateTime.Now;
                        TimeZoneInfo symTimeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
                        var gmtTime = TimeZoneInfo.ConvertTime(timeNow, TimeZoneInfo.Local, symTimeZone);
                        Console.WriteLine($"System time zone changed to GMT! Converted time: {gmtTime}\n");
                        Console.ResetColor();
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        var timeNow1 = DateTime.Now;
                        var utcTime = TimeZoneInfo.ConvertTime(timeNow1, TimeZoneInfo.Local, TimeZoneInfo.Utc);
                        Console.WriteLine($"System time zone changed to UTC! Converted time: {utcTime}\n");
                        Console.ResetColor();
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        var timeUtc = DateTime.UtcNow;
                        TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                        var timeEastern = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
                        Console.WriteLine($"System time zone changed to EST! Converted time: {timeEastern}\n");
                        Console.ResetColor();
                        break;

                    case 4:
                        SystemSettings(); // Return to the configure system parameters menu
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Infinite loop Until the user choose to return to the system settings menu
        }

        private static void ConfigureEmailNotifications()
        {
            do
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
                        Console.WriteLine("Email notifications enabled !\n");
                        Console.ResetColor();
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Email notifications disabled !\n");
                        Console.ResetColor();
                        break;

                    case 3:
                        SystemSettings(); // Return to the configure system parameters menu
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Infinite loop Until the user choose to return to the system settings menu
        }

        public static void SaveAdministratorsToJson()
        {
            string json = JsonConvert.SerializeObject(administrators, Formatting.Indented);

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSaving Administrators...\n");
                File.WriteAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\admin.json", json);
                Console.WriteLine("\nAdmin data saved to 'admin.json' successfully !\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Saving Admin Data: {ex.Message}\n");
                Console.ResetColor();
            }
        }

        public static void LoadAdminsFromJson()
        {
            try
            {
                if (File.Exists(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\admin.json"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nUploading Admins...\n");
                    string json = File.ReadAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\admin.json");
#pragma warning disable CS8601 // Possible null reference assignment.
                    administrators = JsonConvert.DeserializeObject<List<Administrator>>(json);
                    Console.WriteLine("\nAdmin data Uploaded from 'admin.json' successfully !\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n'admin.json' file not found. No admin data Uploaded !\n");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Uploading admin data: {ex.Message} !\n");
                Console.ResetColor();
            }
        }

        public static void SaveStudentWeeklyScheduleToJson()
        {
            string json = JsonConvert.SerializeObject(WeeklyStudentSchedule, Formatting.Indented);

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSaving Student Weekly Schedule...\n");
                File.WriteAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\studentWeeklySchedule.json", json);
                Console.WriteLine("\nStudent Weekly Schedule data saved to 'studentWeeklySchedule.json' successfully !\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Saving Student Weekly Schedule Data: {ex.Message}\n");
                Console.ResetColor();
            }
        }

        public static void LoadStudentWeeklyScheduleFromJson()
        {
            try
            {
                if (File.Exists(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\studentWeeklySchedule.json"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nUploading Students Weekly Schedule...\n");
                    string json = File.ReadAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\studentWeeklySchedule.json");
                    WeeklyStudentSchedule = JsonConvert.DeserializeObject<List<string>>(json);
                    Console.WriteLine("\nStudent Weekly Schedule data Uploaded from 'studentWeeklySchedule.json' successfully !\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n'studentWeeklySchedule.json' file not found. No Students Weekly Schedule data Uploaded !\n");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Uploading Teacher Weekly Schedule data: {ex.Message} !\n");
                Console.ResetColor();
            }
        }

        public static void SaveTeacherWeeklyScheduleToJson()
        {
            string json = JsonConvert.SerializeObject(WeeklyTeacherSchedule, Formatting.Indented);

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSaving Teacher Weekly Schedule...\n");
                File.WriteAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\teacherWeeklySchedule.json", json);
                Console.WriteLine("\nTeacher Weekly Schedule data saved to 'teacherWeeklySchedule.json' successfully !\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Saving Teacher Weekly Schedule Data: {ex.Message}\n");
                Console.ResetColor();
            }
        }

        public static void LoadTeacherWeeklyScheduleFromJson()
        {
            try
            {
                if (File.Exists(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\teacherWeeklySchedule.json"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nUploading Teachers Weekly Schedule...\n");
                    string json = File.ReadAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\teacherWeeklySchedule.json");
                    WeeklyTeacherSchedule = JsonConvert.DeserializeObject<List<string>>(json);
                    Console.WriteLine("\nTeacher Weekly Schedule data Uploaded from 'teacherWeeklySchedule.json' successfully !\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n'teacherWeeklySchedule.json' file not found. No Teachers Weekly Schedule data Uploaded !\n");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Uploading Student Weekly Schedule data: {ex.Message} !\n");
                Console.ResetColor();
            }
        }

        public static void SaveExamsDatesAndDeadlinesToJson()
        {
            string json = JsonConvert.SerializeObject(examsDatesAndDeadlines, Formatting.Indented);

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSaving Exams Dates and Deadlines...\n");
                File.WriteAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\examsDatesAndDeadlines.json", json);
                Console.WriteLine("\nExams Dates and Deadlines data saved to 'examsDatesAndDeadlines.json' successfully !\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Saving Exams Dates and Deadlines Data: {ex.Message}\n");
                Console.ResetColor();
            }
        }

        public static void LoadExamsDatesAndDeadlinesFromJson()
        {
            try
            {
                if (File.Exists(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\examsDatesAndDeadlines.json"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nUploading Exams Dates and Deadlines...\n");
                    string json = File.ReadAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\examsDatesAndDeadlines.json");
                    examsDatesAndDeadlines = JsonConvert.DeserializeObject<List<Administrator>>(json);
                    Console.WriteLine("\nExams Dates and Deadlines data Uploaded from 'examsDatesAndDeadlines.json' successfully !\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n'examsDatesAndDeadlines.json' file not found. No Exams Dates and Deadlines data Uploaded !\n");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Uploading Exams Dates and Deadlines data: {ex.Message} !\n");
                Console.ResetColor();
            }
        }

        public static void SaveUpcomingModulesAndCoursesToJson()
        {
            string json = JsonConvert.SerializeObject(upcomingModulesAndCourses, Formatting.Indented);

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSaving Upcoming Modules and Courses...\n");
                File.WriteAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\upcomingModulesAndCourses.json", json);
                Console.WriteLine("\nUpcoming Modules and Courses data saved to 'upcomingModulesAndCourses.json' successfully !\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Saving Upcoming Modules and Courses Data: {ex.Message}\n");
                Console.ResetColor();
            }
        }

        public static void LoadUpcomingModulesAndCoursesFromJson()
        {
            try
            {
                if (File.Exists(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\upcomingModulesAndCourses.json"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nUploading Upcoming Modules and Courses...\n");
                    string json = File.ReadAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\upcomingModulesAndCourses.json");
                    upcomingModulesAndCourses = JsonConvert.DeserializeObject<List<Administrator>>(json);
                    Console.WriteLine("\nUpcoming Modules and Courses data Uploaded from 'upcomingModulesAndCourses.json' successfully !\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n'upcomingModulesAndCourses.json' file not found. No Upcoming Modules and Courses data Uploaded !\n");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Uploading Upcoming Modules and Courses data: {ex.Message} !\n");
                Console.ResetColor();
            }
        }

        public static void SaveStudentPerformanceReportsToJson()
        {
            string json = JsonConvert.SerializeObject(studentPerformanceReportsList, Formatting.Indented);

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSaving Student Performance Reports...\n");
                File.WriteAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\studentPerformanceReportsList.json", json);
                Console.WriteLine("\nStudent Performance Reports data saved to 'studentPerformanceReportsList.json' successfully !\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Saving Student Performance Reports Data: {ex.Message}\n");
                Console.ResetColor();
            }
        }

        public static void LoadStudentPerformanceReportsFromJson()
        {
            try
            {
                if (File.Exists(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\studentPerformanceReportsList.json"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nUploading Student Performance Reports...\n");
                    string json = File.ReadAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\studentPerformanceReportsList.json");
                    studentPerformanceReportsList = JsonConvert.DeserializeObject<List<Administrator>>(json);
                    Console.WriteLine("\nStudent Performance Reports data Uploaded from 'studentPerformanceReportsList.json' successfully !\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n'studentPerformanceReportsList.json' file not found. No Student Performance Reports data Uploaded !\n");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Uploading Student Performance Reports data: {ex.Message} !\n");
                Console.ResetColor();
            }
        }

        public static void SaveTeacherPerformanceReportsToJson()
        {
            string json = JsonConvert.SerializeObject(teacherPerformanceReportsList, Formatting.Indented);

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSaving Teacher Performance Reports...\n");
                File.WriteAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\teacherPerformanceReportsList.json", json);
                Console.WriteLine("\nTeacher Performance Reports data saved to 'teacherPerformanceReportsList.json' successfully !\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Saving Teacher Performance Reports Data: {ex.Message}\n");
                Console.ResetColor();
            }
        }

        public static void LoadTeacherPerformanceReportsFromJson()
        {
            try
            {
                if (File.Exists(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\teacherPerformanceReportsList.json"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nUploading Teacher Performance Reports...\n");
                    string json = File.ReadAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\teacherPerformanceReportsList.json");
                    teacherPerformanceReportsList = JsonConvert.DeserializeObject<List<Administrator>>(json);
                    Console.WriteLine("\nTeacher Performance Reports data Uploaded from 'teacherPerformanceReportsList.json' successfully !\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n'teacherPerformanceReportsList.json' file not found. No Teacher Performance Reports data Uploaded !\n");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Uploading Teacher Performance Reports data: {ex.Message} !\n");
                Console.ResetColor();
            }
        }

    }
}
