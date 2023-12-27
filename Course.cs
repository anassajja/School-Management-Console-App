using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SCHOOL_MANAGEMENT_CONSOLE_APP
{
    class Course
    {
        public string NameC { get; set; }
        public string AssociatedModule { get; set; }
        public string CourseDebutDate { get; set; }
        public string CourseEndDate { get; set; }
        public string CourseTeacherName { get; set; }
        public string CourseClassroom { get; set; }
        public string CourseClass { get; set; }
        public static string? CoursePath { get; set; } // Path to the associated .txt file for course details
        public static List<Course> Courses { get; set; } = new List<Course>();

        // Constructor

        public Course(string namec, string associatedModule, string courseDebutDate, string courseEndDate, string courseTeacherName, string courseClassroom, string courseClass, string coursePath)
        {
            NameC = namec;
            AssociatedModule = associatedModule;
            CourseDebutDate = courseDebutDate;
            CourseEndDate = courseEndDate;
            CourseTeacherName = courseTeacherName;
            CourseClassroom = courseClassroom;
            CourseClass = courseClass;
            CoursePath = coursePath;
        }
        public static void AddCourse()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                  Add Course:");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter course name : ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string name = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.Write("Enter associated module : ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string associatedModule = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
            Console.WriteLine("");
            Console.Write("Enter course debut date: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
            string courseDebutDate = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
            Console.WriteLine("");
            Console.Write("Enter course end date: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
            string courseEndDate = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
            Console.WriteLine("");
            Console.Write("Enter course teacher name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
            string courseTeacherName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
            Console.WriteLine("");
            Console.Write("Enter course classroom number: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
            string courseClassroom = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
            Console.WriteLine("");
            Console.Write("Enter course class: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
            string courseClass = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
            Console.WriteLine("");
            Console.Write("Enter course file path: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
            string coursePath = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
            Console.WriteLine("");
            #pragma warning disable CS8604 // Possible null reference argument.
            Course newCourse = new(name, associatedModule, courseDebutDate, courseEndDate, courseTeacherName, courseClassroom, courseClass, coursePath);
            #pragma warning restore CS8604 // Possible null reference argument.
            Courses.Add(newCourse);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Course added successfully !");
            Console.ResetColor();
            Console.WriteLine("");
            // Save courses to JSON file
            SaveCoursesToJson();
            Console.WriteLine("");
        }

        public static void ViewCourses()
        {
            Console.ForegroundColor = ConsoleColor.Blue;    
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                    List of Courses                ");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            // Upload courses from JSON file
            LoadCoursesFromJson();
            Console.WriteLine("");

            foreach (var course in Courses)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"Course Name: {course.NameC}, Associated Module: {course.AssociatedModule}, Course Path: {CoursePath}\n");
                Console.ResetColor();
            }
        }

        public static void UpdateCourse()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                  Update Course:");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter course name to update: "); 
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
            string name = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
            Console.WriteLine("\n");
            foreach (var course in Courses)
            {
                if (course.NameC == name)
                {
                    Console.Write("Enter new course name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
                    string newNameC = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
                    Console.WriteLine("");
                    Console.Write("Enter new course associated module: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
                    string newAssociatedModule = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
                    Console.WriteLine("");
                    Console.Write("Enter new course file path: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
                    string newCoursePath = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
                    Console.WriteLine("");
                    Console.Write("Enter new course debut date: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
                    string newCourseDebutDate = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
                    Console.WriteLine("");
                    Console.Write("Enter new course end date: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
                    string newCourseEndDate = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
                    Console.WriteLine("");
                    Console.Write("Enter new course teacher name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
                    string newCourseTeacherName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
                    Console.WriteLine("");
                    Console.Write("Enter new course classroom number: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
                    string newCourseClassroom = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
                    Console.WriteLine("");
                    Console.Write("Enter new course class: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
                    string newCourseClass = Console.ReadLine();         
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'
                    Console.WriteLine("");
#pragma warning disable CS8601 // Possible null reference assignment.
                    course.CourseClass = newCourseClass;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                    course.CourseClassroom = newCourseClassroom;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                    course.CourseTeacherName = newCourseTeacherName;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.   
                    course.CourseEndDate = newCourseEndDate;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                    course.CourseDebutDate = newCourseDebutDate;
#pragma warning restore CS8601 // Possible null reference assignment.
                    CoursePath = newCoursePath;
#pragma warning disable CS8601 // Possible null reference assignment.
                    course.NameC = newNameC;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                    course.AssociatedModule = newAssociatedModule;
#pragma warning restore CS8601 // Possible null reference assignment.
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("");
                    Console.WriteLine("Course updated successfully !");
                    Console.ResetColor();
                    Console.WriteLine("");
                    // Save courses to JSON file
                    SaveCoursesToJson();
                    Console.WriteLine("");
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Course not found !\n");
                    Console.ResetColor();
                }
            }
        }

        public static void DeleteCourse()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                  Delete Course:");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter course name to delete: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.'
            string nameToDelete = Console.ReadLine();       
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.'

            foreach(var course in Courses)
            {
                if (course.NameC == nameToDelete)
                {
                    Courses.Remove(course);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Course deleted successfully.\n");
                    Console.ResetColor();
                    Console.WriteLine("");
                    // Save courses to JSON file
                    SaveCoursesToJson();
                    Console.WriteLine("");
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Course not found.\n");
                    Console.ResetColor();
                }
            }
        }

        public static void DisplayCourseDetails(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    Console.WriteLine(File.ReadAllText(filePath));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("File not found.\n");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ResetColor();
            }
        }

        public static void ManageCourses()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n=======================================\n");
                Console.WriteLine("           Courses Management System       ");
                Console.WriteLine("\n=======================================\n");
                Console.WriteLine("1. Add Course\n");
                Console.WriteLine("2. View Courses\n");
                Console.WriteLine("3. Display Course Details\n");
                Console.WriteLine("4. Update Course\n");
                Console.WriteLine("5. Delet Course\n");
                Console.WriteLine("6. Back to main menu\n");
                Console.ResetColor();
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine('\n');

                switch (choice)
                {
                    case 1:
                        AddCourse();
                        break;

                    case 2:
                        ViewCourses();
                        break;

                    case 3:
#pragma warning disable CS8604 // Possible null reference argument.
                        DisplayCourseDetails(CoursePath);
#pragma warning restore CS8604 // Possible null reference argument.
                        break;

                    case 4:
                        UpdateCourse();
                        break;

                    case 5:
                        DeleteCourse();
                        break;

                    case 6:
                        Program.MainMenu();
                        break; // Retuns to main menu

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                } 

            } while (true); // Infinite loop
        }

        public static void SaveCoursesToJson()
        {
            string json = JsonConvert.SerializeObject(Courses, Formatting.Indented);

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Saving Courses...");
                File.WriteAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\course.json", json);
                Console.WriteLine("Course data saved to 'course.json' successfully !");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error Saving Course Data: {ex.Message}\n");
                Console.ResetColor();
            }
        }

        public static void LoadCoursesFromJson()
        {
            try
            {
                if (File.Exists(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\course.json"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("");
                    Console.WriteLine("Uploading Courses...");
                    string json = File.ReadAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\course.json");
#pragma warning disable CS8601 // Possible null reference assignment.
                    Courses = JsonConvert.DeserializeObject<List<Course>>(json);
                    Console.WriteLine("");
                    Console.WriteLine("Admin data Uploaded from 'course.json' successfully !\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n'course.json' file not found. No course data Uploaded !\n");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Uploading course data: {ex.Message} !\n");
                Console.ResetColor();
            }
        }
    }
}