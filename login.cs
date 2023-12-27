using System;
using System.Collections.Generic;
using System.Net;

namespace SCHOOL_MANAGEMENT_CONSOLE_APP
{
    class Login : User
    {
        public DateTime Session { get; set; }
        public static Login? CurrentUser { get; internal set; }

        public Login(string username, string password, string role, DateTime session) : base(username, password, role)
        { 
            Session = session;
        }

        /// <summary>
        /// Logs in a user by prompting for username, password, and role, and checks if the user is valid.
        /// </summary>
        
        public static void LoginUser()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n=======================================================\n");
            Console.WriteLine("              Login To Your Account:                       ");
            Console.WriteLine("\n=======================================================\n");
            Console.ResetColor();
            Console.Write("Enter your username: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string username = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.Write("Enter your password: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string password = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            Console.Write("Please Select Your Role ( admin , teacher , student ) : ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string role = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("");
            DateTime session = DateTime.Now;
#pragma warning disable CS8604 // Possible null reference argument.
            Login login = new(username, password, role, session);
#pragma warning restore CS8604 // Possible null reference argument.
            if (login.CheckUser())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login Successful !\n");
                Console.WriteLine("Welcome " + login.Username);
                Console.WriteLine("");
                Console.WriteLine("Role: " + login.Role);
                Console.WriteLine("");
                Console.WriteLine("Session: " + login.Session);
                Console.WriteLine("");
                Console.ResetColor();
                CurrentUser = login;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login Failed ! This User does not exist !\n");
                Console.ResetColor();
            }
        }

        public bool CheckUser()
        {
            foreach (var user in Users)
            {
                if (user.Username == Username && user.Password == Password && user.Role == Role)
                {
                    return true;
                }
            }
            return false;
        }

        public static void LogoutUser(Login login)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=======================================================\n");
            Console.WriteLine($"Logging out: {login.Username}\n");
            Console.WriteLine("Session Ended !");
            Console.WriteLine("\n=======================================================\n");
            Console.ResetColor();
        }
    }
}