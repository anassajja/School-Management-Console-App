using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SCHOOL_MANAGEMENT_CONSOLE_APP
{

    class User
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

        public static List<User> Users { get; set; } = new ();

        // Constructor
        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public static void AddUser()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                  Add User:");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            // Prompt user to enter user details
            Console.Write("Enter user Username: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string username = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.Write("Enter user Password: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string password = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.Write("Enter user Role ( admin, teacher, student ): ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string role = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
            User newUser = new(username, password, role);
#pragma warning restore CS8604 // Possible null reference argument.
            // Ensure that Users is not null before adding a new user
            Users ??= new List<User>();
            Users.Add(newUser);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("User added successfully!");
            Console.ResetColor();
            Console.WriteLine("");
            // Save users to JSON file
            SaveUsersToJson();
            Console.WriteLine("");
        }

        public static void ViewUsers()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                    List of Users:");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            // Upload users from JSON file
            LoadUsersFromJson();
            Console.Write("Enter your role (admin, teacher, student): ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string role = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            if (role != "admin")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You are not authorized to view users.\n");
                Console.ResetColor();
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You are authorized to view users.\n");
                Console.ResetColor();
                foreach (var user in Users)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"Username: {user.Username}");
                    Console.WriteLine("");
                    Console.WriteLine($"Password: {user.Password}");
                    Console.WriteLine("");
                    Console.WriteLine($"Role: {user.Role}");
                    Console.WriteLine("");
                    Console.WriteLine("------------------------------------------------");
                    Console.ResetColor();
                }
            }
        }

        public static void UpdateUser()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                  Update User:");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter user Username: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string username = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            User userToUpdate = Users.Find(user => user.Username == username);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (userToUpdate != null)
            {
                Console.Write("Enter New User Username: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string newUsername = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("");
                Console.Write("Enter New User Password: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string newPassword = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("");
                Console.Write("Enter New User Role: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string newRole = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("");
                userToUpdate.Username = newUsername;
                userToUpdate.Password = newPassword;
                userToUpdate.Role = newRole;
                Users.Add(userToUpdate);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User Updated Successfully !");
                Console.ResetColor();
                Console.WriteLine("");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User not found !\n");
                Console.ResetColor();
            }
            // Save users to JSON file
            SaveUsersToJson();
            Console.WriteLine("");
        }

        public static void DeleteUser()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n************************************************\n");
            Console.WriteLine("                     Delete User:");
            Console.WriteLine("\n************************************************\n");
            Console.ResetColor();
            Console.Write("Enter user Username: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string username = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            User userToRemove = Users.Find(user => user.Username == username);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (userToRemove != null)
            {
                Users.Remove(userToRemove);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User deleted successfully !");
                Console.ResetColor();
                Console.WriteLine("");
                // Save users to JSON file
                SaveUsersToJson();
                Console.WriteLine("");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User not found !\n");
                Console.ResetColor();
            }
        }

        public static void ManageUsers()
        {
            do 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n=======================================\n");
                Console.WriteLine("          User Management System           ");
                Console.WriteLine("\n=======================================\n");
                Console.WriteLine("User Management\n");
                Console.WriteLine("1. Add User\n");
                Console.WriteLine("2. View Users\n");
                Console.WriteLine("3. Update User\n");
                Console.WriteLine("4. Delete User\n");
                Console.WriteLine("5. Back to main Menu\n");
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
                        Program.MainMenu();
                        break; // Return to the main menu
                            
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Try again !");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Infinite loop
        }

        public static void SaveUsersToJson()
        {
            string json = JsonConvert.SerializeObject(Users, Formatting.Indented);

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSaving Users...\n");
                File.WriteAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\user.json", json);
                Console.WriteLine("\nUser data saved to 'user.json' successfully !\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError Saving User Data: {ex.Message}\n");
                Console.ResetColor();
            }
        }

        public static void LoadUsersFromJson()
        {
            try
            {
                if (File.Exists(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\user.json"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nUploading Students...\n");
                    string json = File.ReadAllText(@"C:\Users\luffy\OneDrive\Bureau\School Management Console App\JSON\user.json");
#pragma warning disable CS8601 // Possible null reference assignment.
                    Users = JsonConvert.DeserializeObject<List<User>>(json);
                    Console.WriteLine("\nUser data Uploaded from 'user.json' successfully !\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n'user.json' file not found. No user data Uploaded !\n");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError uploading user data: {ex.Message} !\n");
                Console.ResetColor();
            }
        }
    }
}