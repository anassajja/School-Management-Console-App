using System;
using System.Collections.Generic;

namespace SCHOOL_MANAGEMENT_CONSOLE_APP
{
    class Student : Person
    {
        // Properties

        public string Class { get; set; }

        public string Level { get; set; }

        public string Experise { get; set;}

        public static List<Student> students = new();

        // Constructor
        public Student(string firstName, string lastName, string gender, int id, int phoneNumber, string email, string address, DateTime dateOfBirth, string nationality, string cclass, string level, string expertise) : base(firstName, lastName, gender, id, phoneNumber, email, address, dateOfBirth, nationality)
        {
            Gender = gender;
            Level = level;
            Class = cclass; 
            Experise = expertise;
        }

        public static void AddStudent()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter Student First Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string firstName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.Write("Enter Student Last Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string lastName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.WriteLine("Enter Student Gender: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string gender = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.Write("Enter Student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
            Console.Write("Enter Student Phone Number: ");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
            Console.Write("Enter Student Email: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string email = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.Write("Enter Student Address: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string address = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.Write("Enter Student Date of Birth: ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("\n");
            Console.WriteLine("Enter Student Nationality: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string nationality = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.WriteLine("Enter Student Class: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string cclass = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.Write("Enter Student Level: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string level = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.Write("Enter Student Expertise: ");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string expertise = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            #pragma warning disable CS8604 // Possible null reference argument.
            Student newStudent = new(firstName, lastName, gender, id, phoneNumber, email, address, dateOfBirth, nationality, cclass, level, expertise);
            #pragma warning restore CS8604 // Possible null reference argument.
            students.Add(newStudent);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nStudent added successfully!\n");
            Console.ResetColor();
        }

        public static void ViewStudents()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                  List of Students");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            foreach (var student in students)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"First Name: {student.FirstName}, Last Name: {student.LastName}, Gender: {student.Gender}, ID: {student.Id}, Phone Number: {student.PhoneNumber}, Email: {student.Email}, Address: {student.Address}, Birth Date: {student.DateOfBirth}, Nationality: {student.Nationality}, Class {student.Class}, Level: {student.Level}, Expertise {student.Experise} \n");
                Console.ResetColor();
            }
        }

        public static void UpdateStudent()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter Student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Student studentToUpdate = students.Find(s => s.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (studentToUpdate != null)
            {
                Console.Write("Enter new Student First Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string firstName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.Write("Enter new Student Last Name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string lastName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.WriteLine("Enter new student Gender:");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string gender = Console.ReadLine();
                Console.WriteLine("\n");
                Console.Write("Enter new Student ID: ");
                int newId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");
                Console.WriteLine("Enter new Student Phone Number: ");
                int phoneNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");
                Console.WriteLine("Enter new Student Email: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string email = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.WriteLine("Enter new Student Address: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string address = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.WriteLine("Enter new Student Date of Birth: ");
                DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("\n");
                Console.WriteLine("Enter new Student Nationality: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string nationality = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.Write("Enter new Student Class: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string cclass = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type
                Console.WriteLine("\n");
                Console.Write("Enter new student level: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string level = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
                Console.Write("Enter new student expertise: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string expertise = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\n");
#pragma warning disable CS8601 // Possible null reference assignment.
                studentToUpdate.FirstName = firstName;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                studentToUpdate.LastName = lastName;
#pragma warning restore CS8601 // Possible null reference assignment.
                studentToUpdate.Id = newId;
#pragma warning disable CS8601 // Possible null reference assignment.
                studentToUpdate.Gender = gender;
                studentToUpdate.PhoneNumber = phoneNumber;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                studentToUpdate.Email = email;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                studentToUpdate.Address = address;
#pragma warning restore CS8601 // Possible null reference assignment.
                studentToUpdate.DateOfBirth = dateOfBirth;
#pragma warning disable CS8601 // Possible null reference assignment.
                studentToUpdate.Nationality = nationality;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                studentToUpdate.Class = cclass;
                studentToUpdate.Level = level;
                studentToUpdate.Experise = expertise;
                students.Add(studentToUpdate);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Student updated successfully!\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student not found.\n");
                Console.ResetColor();
            }
        }


        public static void DeleteStudent()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Student studentToRemove = students.Find(s => s.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Student deleted successfully!\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student not found.\n");
                Console.ResetColor();
            }
        }

        public static void ManageStudents()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=======================================\n");
            Console.WriteLine("          Student Management System        ");
            Console.WriteLine("\n=======================================\n");
            Console.WriteLine("1. Add Student\n");
            Console.WriteLine("2. View Students\n");
            Console.WriteLine("3. Update Student\n");
            Console.WriteLine("4. Delete Student\n");
            Console.WriteLine("5. Back to main menu\n");
            Console.ResetColor(); // Reset color to default
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine('\n');

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;

                case 2:
                    ViewStudents();
                    break;

                case 3:
                    UpdateStudent();
                    break;

                case 4:
                    DeleteStudent();
                    break;

                case 5:
                    return; // Retuns to main menu

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }  
        }

    }
}
