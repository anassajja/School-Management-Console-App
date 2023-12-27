using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SCHOOL_MANAGEMENT_CONSOLE_APP
{
    class Teacher : Person
    {
        public string AssignedCourse { get; set; }

        public static List<Teacher> teachers = new();

        public static List<string>? WeeklyTeacherSchedule { get; set; }

        // Constructor
        public Teacher(string firstName, string lastName, string gender, int id, int phoneNumber, string email, string address, DateTime dateOfBirth, string nationality, string assignedCourse) : base(firstName, lastName, gender, id, phoneNumber, email, address, dateOfBirth, nationality)
        {
            AssignedCourse = assignedCourse;
        }

        public static void AddTeacher()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                  Add Teacher:");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter teacher First name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string firstName = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Enter teacher Last name: ");
            string lastName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.WriteLine("Enter Teacher Gender : ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string gender = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.Write("Enter teacher ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Enter teacher hone number: ");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Enter teacher Email: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string email = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.Write("Enter teacher Address: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string address = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.Write("Enter teacher Date of birth: ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Enter teacher Nationality: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string nationality = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.Write("Enter teacher Assigned Course: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string assignedCourse = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
#pragma warning disable CS8604 // Possible null reference argument.
            Teacher newTeacher = new(firstName, lastName, gender, id, phoneNumber, email, address, dateOfBirth, nationality, assignedCourse);
#pragma warning restore CS8604 // Possible null reference argument.
            teachers.Add(newTeacher);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Teacher Added Successfully !");
            Console.ResetColor();
            Console.WriteLine("");
            // Save teachers to json
            SaveTeachersToJson();
            Console.WriteLine("");
        }

        public static void DisplayTeacherDetails()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                   Display Teacher Details:                 ");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter teacher ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            // Upload teachers from json
            LoadTeachersFromJson();
            Console.WriteLine("");
            // Find teacher by id
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Teacher teacher = teachers.Find(t => t.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (teacher != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("                Teacher Details:                 ");
                Console.WriteLine($"Teacher ID : {teacher.Id} \t Teacher First Name : {teacher.FirstName} \t Teacher Last Name : {teacher.LastName} \t Teacher Gender : {teacher.Gender} \t Teacher Phone Number : {teacher.PhoneNumber} \t Teacher Email : {teacher.Email} \t Teacher Address: {teacher.Address} \t Teacher Birth Date : {teacher.DateOfBirth} \t Teacher Nationality : {teacher.Nationality} \t Teacher Assigned Course : {teacher.AssignedCourse}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Teacher not found !\n");
                Console.ResetColor();
            }
        }

        public static void ViewTeachers()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                   List of Teachers:                 ");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            // Upload teachers from json
            LoadTeachersFromJson();
            Console.WriteLine("");
            foreach (var teacher in teachers)
            {
                if (teachers.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Teacher N`{0} : ", teachers.IndexOf(teacher) + 1);
                    Console.WriteLine($"Teacher ID : {teacher.Id} \t Teacher Full Name : {teacher.FirstName + " "}{teacher.LastName} ");
                    Console.ResetColor();  
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No Teachers found !");
                    Console.ResetColor();
                }
            }
        }

        public static void UpdateTeacher()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                  Update Teacher:");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter teacher ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());  
            Console.WriteLine("\n");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Teacher teacherToUpdate = teachers.Find(t => t.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
    
                if (teacherToUpdate != null)
                {
                    Console.Write("Enter new teacher first name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string newFirstName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.WriteLine("");
                    Console.Write("Enter new teacher last name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string lastName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.WriteLine("");
                    Console.WriteLine("Enter new teacher gender: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string gender = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.Write("Enter new teacher ID: ");
                    int id2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("");
                    Console.Write("Enter new teacher phone number: ");
                    int phoneNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("");
                    Console.Write("Enter new teacher email: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string email = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.WriteLine("");
                    Console.Write("Enter new teacher address: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string address = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.WriteLine("");
                    Console.Write("Enter new teacher date of birth: ");
                    DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("");
                    Console.WriteLine("Enter new teacher nationality");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string nationality = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.WriteLine("");
                    Console.Write("Enter new teacher Assigned Course: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string assignedCourse = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.WriteLine("");
#pragma warning disable CS8601 // Possible null reference assignment.
                teacherToUpdate.FirstName = newFirstName;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                teacherToUpdate.LastName = lastName;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                teacherToUpdate.Gender = gender;
#pragma warning restore CS8601 // Possible null reference assignment.
                teacherToUpdate.Id = id2;
                teacherToUpdate.PhoneNumber = phoneNumber;
#pragma warning disable CS8601 // Possible null reference assignment.
                teacherToUpdate.Email = email;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                teacherToUpdate.Address = address;
#pragma warning restore CS8601 // Possible null reference assignment.
                teacherToUpdate.DateOfBirth = dateOfBirth;
#pragma warning disable CS8601 // Possible null reference assignment.
                teacherToUpdate.Nationality = nationality;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                teacherToUpdate.AssignedCourse = assignedCourse;
#pragma warning restore CS8601 // Possible null reference assignment.
                teachers.Add(teacherToUpdate);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teacher Updated Successfully !");
                Console.ResetColor();
                Console.WriteLine("");
                // Save teachers to json
                SaveTeachersToJson();
                Console.WriteLine("");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Teacher not found !\n");
                Console.ResetColor();
            }
        }   

        public static void DeleteTeacher()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                  Delete Teacher:");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter teacher ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Teacher teacherToRemove = teachers.Find(t => t.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (teacherToRemove != null)
            {
                teachers.Remove(teacherToRemove);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teacher deleted successfully !");
                Console.ResetColor();
                Console.WriteLine("");
                // Save teachers to json
                SaveTeachersToJson();
                Console.WriteLine("");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Teacher not found !");
                Console.ResetColor();
            }
        }

        public static void ManageTeachers()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n=======================================\n");
                Console.WriteLine("         Teacher Management System         ");
                Console.WriteLine("\n=======================================\n");
                Console.WriteLine("1. Add Teacher\n");
                Console.WriteLine("2. Display Teacher Details\n");
                Console.WriteLine("3. View Teachers\n");
                Console.WriteLine("4. Update Teacher\n");
                Console.WriteLine("5. Delete Teacher\n");
                Console.WriteLine("6. Back to main menu\n");
                Console.ResetColor(); // Reset color to default
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                switch (choice)
                {
                    case 1:
                        AddTeacher();
                        break;

                    case 2:
                        DisplayTeacherDetails();
                        break;

                    case 3:
                        ViewTeachers();
                        break;

                    case 4:
                        UpdateTeacher();
                        break;

                    case 5:
                        DeleteTeacher();
                        break;

                    case 6:
                        Program.MainMenu();
                        break; // Returns to main menu
                            
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again.\n");
                        Console.ResetColor();
                        break;
                }
            } while (true); // Loop until user enters 6 to return to main menu
        }

       public static void SaveTeachersToJson()
        {
            string json = JsonConvert.SerializeObject(teachers, Formatting.Indented);

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSaving Teachers...\n");
                File.WriteAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\teacher.json", json);
                Console.WriteLine("\nTeacher data saved to 'teacher.json' successfully !\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Saving Student Data: {ex.Message} !\n");
                Console.ResetColor();
            }
        }

        public static void LoadTeachersFromJson()
        {
            try
            {
                if (File.Exists(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\teacher.json"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nUploading Teachers...\n");
                    string json = File.ReadAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\student.json");
#pragma warning disable CS8601 // Possible null reference assignment.
                    teachers = JsonConvert.DeserializeObject<List<Teacher>>(json);
#pragma warning restore CS8601 // Possible null reference assignment.
                    Console.WriteLine("\nTeachers data uploaded from 'teacher.json' successfully !\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nFile 'teacher.json' not found. No teacher data Uploaded !\n");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Uploading Teachers Data: {ex.Message} !\n");
                Console.ResetColor();
            }
        }
    }
}
