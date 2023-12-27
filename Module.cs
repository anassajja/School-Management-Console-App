using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace SCHOOL_MANAGEMENT_CONSOLE_APP
{

    class Module: Course
    {
        public string NameM { get; set; }
        public int CoursesNumber { get; set; }
        public static List<Module> Modules { get; set; } = new List<Module>();

        // Constructor
        public Module(string nameM, int coursesNumber, string nameC) : base(nameC, "", "", "", "", "", "", "")
        {
            NameM = nameM;
            CoursesNumber = coursesNumber;
        }

        public static void AddModule()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                  Add Module:");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter module name : ");
        #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string moduleName = Console.ReadLine();
        #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.Write("Enter courses number : ");
            int coursesNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
#pragma warning disable CS8604 // Possible null reference argument.
            Module newModule = new(moduleName, coursesNumber, ""); // Pass the required arguments to the Module constructor
#pragma warning restore CS8604 // Possible null reference argument.
            Modules.Add(newModule);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Module added successfully !");
            Console.ResetColor();
            Console.WriteLine("");
            // Save the modules to JSON file
            SaveModulesToJson();
            Console.WriteLine("");
        }

        public static void AddCourseToModule()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                  Add Course To Module:");
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
                do
                {
                    Console.Write("Enter course name: ");
    #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string courseName = Console.ReadLine();
    #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.WriteLine("");

                    #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    Course selectedCourse = Courses.Find(course => course.NameC == courseName);
                    #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                    if (selectedCourse != null)
                    {
                        Courses.Add(selectedCourse);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Course added to module successfully !");
                        Console.ResetColor();
                        Console.WriteLine("");
                        // Save the modules to JSON file
                        SaveModulesToJson();
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Course not found !\n");
                        Console.ResetColor();
                    }

                    Console.Write("Do you want to add another course to this module ? (y/n) : ");

                } while (Console.ReadLine() == "y" || Console.ReadLine() == "Y");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Module not found !\n");
                Console.ResetColor();
            }

        }

        public static void ViewModules()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                  List of Modules:");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            // Save the modules to JSON file   
            LoadModulesFromJson();
            Console.WriteLine("");

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
            Console.WriteLine("                  Delete Module:");
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
                    Console.WriteLine("Module deleted successfully !");
                    Console.ResetColor();
                    Console.WriteLine("");
                    // Save the modules to JSON file
                    SaveModulesToJson();
                    Console.WriteLine("");
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
            do
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
                        Program.MainMenu(); // Go back to main menu
                        break; // Exit the switch statement

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Loop until the user enters a valid choice
        }

        public static void SaveModulesToJson()
        {
            string json = JsonConvert.SerializeObject(Modules, Formatting.Indented);

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Saving Modules...");
                File.WriteAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\module.json", json);
                Console.WriteLine("Module data saved to 'module.json' successfully !");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error Saving Module Data: {ex.Message}\n");
                Console.ResetColor();
            }
        }

        public static void LoadModulesFromJson()
        {
            try
            {
                if (File.Exists(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\module.json"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nUploading Modules...\n");
                    string json = File.ReadAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\module.json");
#pragma warning disable CS8601 // Possible null reference assignment.
                    Modules = JsonConvert.DeserializeObject<List<Module>>(json);
                    Console.WriteLine("\nModule data Uploaded from 'module.json' successfully !\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n'module.json' file not found. No module data Uploaded !\n");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError uploading module data: {ex.Message} !\n");
                Console.ResetColor();
            }
        }
    }
}
