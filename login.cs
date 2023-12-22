using System;
using System.Collections.Generic;

namespace SCHOOL_MANAGEMENT_CONSOLE_APP
{
    class Login : User
    {
        public DateTime Session { get; set; }
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
            Console.WriteLine("Enter your username: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string username = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("Enter your password: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string password = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine("Please select your role < Admin ; Teacher ; Student > : ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string role = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            DateTime session = DateTime.Now;
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8604 // Possible null reference argument.
            Login login = new(username, password, role, session);
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8604 // Possible null reference argument.
            if (login.CheckUser())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login Successful !");
                Console.WriteLine("Welcome " + login.Username);
                Console.WriteLine("Role: " + login.Role);
                Console.WriteLine("Session: " + login.Session);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login Failed !");
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
    }
}