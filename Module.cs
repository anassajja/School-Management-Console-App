using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;

namespace SCHOOL_MANAGEMENT_CONSOLE_APP
{

    class Module: Course
    {
        public string NameM { get; set; }
        public static List<Module> Modules { get; set; } = new List<Module>();

        // Constructor
        public Module(string nameM, string nameC, string description, string courseFilePath) 
            : base(nameC, "", "", "", "", "", "", "")
        {
            NameM = nameM;
        }

        public static void AddModule()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter module name: ");
        #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string moduleName = Console.ReadLine();
        #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
        #pragma warning disable CS8604 // Possible null reference argument.
            Module newModule = new(moduleName, "", "", ""); // Pass the required arguments to the Module constructor
        #pragma warning restore CS8604 // Possible null reference argument.
            Modules.Add(newModule);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nModule added successfully!\n");
            Console.ResetColor();
        }

        public static void AddCourseToModule()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter module name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string moduleName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Module selectedModule = Modules.Find(module => module.NameM == moduleName);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (selectedModule != null)
            {
                Console.Write("Enter course name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string courseName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");

                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                Course selectedCourse = Courses.Find(course => course.NameC == courseName);
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                if (selectedCourse != null)
                {
                    Module.Courses.Add(selectedCourse);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCourse added to module successfully!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCourse not found.\n");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nModule not found.\n");
                Console.ResetColor();
            }
        }

        public static void ViewModules()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("List of Modules:");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();

            foreach (var module in Modules)
            {
                Console.WriteLine($"Module : {module.NameM}\n");
                foreach (var course in Courses)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;   
                    Console.WriteLine($"Course : {course.NameC},");
                    Console.ResetColor();
                }
            }
        }

        public static void DeleteModule()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter module name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string moduleNameToDelete = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.                        
            Console.WriteLine("\n");
            foreach (var module in Modules)
            {
                if (module.NameM == moduleNameToDelete)
                {
                    Modules.Remove(module);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Module deleted successfully!\n");
                    Console.ResetColor();
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Module not found.\n");
                    Console.ResetColor();
                }
            }
        }

        public static void ManageModules()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n==================================================\n");
            Console.WriteLine("               Modules Management System              ");
            Console.WriteLine("\n==================================================\n");
            Console.WriteLine("1. Add Module\n");
            Console.WriteLine("2. Add Course To Module \n");
            Console.WriteLine("3. Display Module Details\n");
            Console.WriteLine("4. Delete Module\n");
            Console.WriteLine("5. Back to main menu\n");
            Console.ResetColor(); // Reset color to default
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddModule();
                    break;

                case 2:
                    AddCourseToModule();
                    break;

                case 3:
                    ViewModules();
                    break;

                case 4:
                    DeleteModule();
                    break;

                case 5:
                    return; 

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
