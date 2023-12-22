using System;
using System.Collections.Generic;

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
            Console.ResetColor();
            Console.Write("Enter teacher First name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string firstName = Console.ReadLine();
            Console.WriteLine("\n");
            Console.Write("Enter teacher Last name: ");
            string lastName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.WriteLine("Enter Teacher Gender : ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string gender = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.Write("Enter teacher ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
            Console.Write("Enter teacher hone number: ");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
            Console.Write("Enter teacher Email: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string email = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.Write("Enter teacher Address: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string address = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.Write("Enter teacher Date of birth: ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("\n");
            Console.Write("Enter teacher Nationality: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string nationality = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.Write("Enter teacher Assigned Course: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string assignedCourse = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
#pragma warning disable CS8604 // Possible null reference argument.
            Teacher newTeacher = new(firstName, lastName, gender, id, phoneNumber, email, address, dateOfBirth, nationality, assignedCourse);
#pragma warning restore CS8604 // Possible null reference argument.
            teachers.Add(newTeacher);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTeacher Added Successfully!\n");
            Console.ResetColor();
        }

        public static void ViewTeachers()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("List of Teachers:");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();

            foreach (var teacher in teachers)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"First Name: {teacher.FirstName}, Last Name: {teacher.LastName}, Gender: {teacher.Gender}, ID: {teacher.Id}, Phone Number: {teacher.PhoneNumber}, Email: {teacher.Email}, Address: {teacher.Address}, Birth Date: {teacher.DateOfBirth}, Nationality: {teacher.Nationality}, Expertise: {teacher.AssignedCourse}\n");
                Console.ResetColor();
            }
        }

        public static void UpdateTeacher()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
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
                    Console.WriteLine("\n");
                    Console.Write("Enter new teacher last name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string lastName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.WriteLine("\n");
                    Console.WriteLine("Enter new teacher gender: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string gender = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.Write("Enter new teacher ID: ");
                    int id2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n");
                    Console.Write("Enter new teacher phone number: ");
                    int phoneNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n");
                    Console.Write("Enter new teacher email: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string email = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.WriteLine("\n");
                    Console.Write("Enter new teacher address: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string address = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.WriteLine("\n");
                    Console.Write("Enter new teacher date of birth: ");
                    DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("\n");
                    Console.WriteLine("Enter new teacher nationality");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string nationality = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.WriteLine("\n");
                    Console.Write("Enter new teacher Assigned Course: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string assignedCourse = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.WriteLine("\n");
#pragma warning disable CS8604 // Possible null reference argument.
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
#pragma warning restore CS8604 // Possible null reference argument.
                teachers.Add(teacherToUpdate);
                Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Teacher Updated Successfully!\n");
                    Console.ResetColor();
            }
        }   

        public static void DeleteTeacher()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.Write("Enter teacher ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Teacher teacherToRemove = teachers.Find(t => t.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (teacherToRemove != null)
            {
                teachers.Remove(teacherToRemove);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teacher deleted successfully!\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Teacher not found.\n");
                Console.ResetColor();
            }
        }

        public static void ManageTeachers()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=======================================\n");
            Console.WriteLine("         Teacher Management System         ");
            Console.WriteLine("\n=======================================\n");
            Console.WriteLine("1. Add Teacher\n");
            Console.WriteLine("2. View Teachers\n");
            Console.WriteLine("3. Update Teacher\n");
            Console.WriteLine("4. Delete Teacher\n");
            Console.WriteLine("5. Back to main menu\n");
            Console.ResetColor(); // Reset color to default
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine('\n');

            switch (choice)
            {
                case 1:
                    AddTeacher();
                    break;

                case 2:
                    ViewTeachers();
                    break;

                case 3:
                    UpdateTeacher();
                    break;

                case 4:
                    DeleteTeacher();
                    break;

                case 5:
                    break; // Returns to main menu
                    
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
