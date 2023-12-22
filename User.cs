using System;
using System.Diagnostics.Contracts;

namespace SCHOOL_MANAGEMENT_CONSOLE_APP
{

    class User : Person
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public static List<User> Users { get; set; } = new List<User>();

        // Constructor
        public User(string username, string password, string role) : base("", "", "", 0, 0, "", "", DateTime.Now, "")
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public static void AddUser()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter user Username: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string username = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.Write("Enter user Password: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string password = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            Console.Write("Enter user Role (admin, teacher, student):");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string role = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
#pragma warning disable CS8604 // Possible null reference argument.
            User newUser = new(username, password, role);
#pragma warning restore CS8604 // Possible null reference argument.
            Users.Add(newUser);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nUser added successfully!\n");
            Console.ResetColor();
        }

        public static void ViewUsers()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("List of Users:");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();

            foreach (var user in Users)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"Username: {user.Username}");
                Console.WriteLine($"Password: {user.Password}");
                Console.WriteLine($"Role: {user.Role}");
                Console.ResetColor();
            }
        }

        public static void UpdateUser()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter user Username: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string username = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            foreach (var user in Users)
            {
                if (user.Username == username)
                {
                    Console.Write("Enter new user Username: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string newUsername = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.WriteLine("\n");
                    Console.Write("Enter new user Password: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string newPassword = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.WriteLine("\n");
                    Console.Write("Enter new user Role (admin, teacher, student):");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string newRole = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    Console.WriteLine("\n");
#pragma warning disable CS8601 // Possible null reference assignment.
                    user.Username = newUsername;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                    user.Password = newPassword;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                    user.Role = newRole;
#pragma warning restore CS8601 // Possible null reference assignment.
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nUser updated successfully!\n");
                    Console.ResetColor();
                }
            }
        }

        public static void DeleteUser()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter user Username: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string username = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("\n");
            foreach (var user in Users)
            {
                if (user.Username == username)
                {
                    Users.Remove(user);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nUser deleted successfully!\n");
                    Console.ResetColor();
                }
            }
        }

        public static void ManageUsers()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=======================================\n");
            Console.WriteLine("          User Management System           ");
            Console.WriteLine("\n=======================================\n");
            Console.WriteLine("User Management");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. View Users");
            Console.WriteLine("3. Update User");
            Console.WriteLine("4. Delete User");
            Console.WriteLine("5. Back to main Menu");
            Console.ResetColor();
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            switch (choice)
            {
                case 1:
                    AddUser();
                    break;

                case 2:
                    ViewUsers();
                    break;

                case 3:
                    UpdateUser();
                    break;

                case 4:
                    DeleteUser();
                    break;

                case 5:
                    return; // Return to the main menu
                    
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.\n");
                    Console.ResetColor();
                    break;
            }
        }
    }
}