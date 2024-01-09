using System;
using System.Runtime.InteropServices;

namespace SCHOOL_MANAGEMENT_CONSOLE_APP
{
    class Program
    {
        [DllImport("winmm.dll", CharSet = CharSet.Unicode)]
#pragma warning disable SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time
        public static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);
#pragma warning restore SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time
        public static void Main()
        {
            // Specify the sound file path
            string soundPath = @"C:\Users\luffy\OneDrive\Bureau\School Management Console App\Music\DrDre.wav";
            // Use the SND_ASYNC flag to play the sound asynchronously
            uint flags = 0x1 | 0x2;
            // Call PlaySound function
            PlaySound(soundPath, IntPtr.Zero, flags);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("          Enjoy Listening DR DRE Music          ");
            Console.ResetColor(); // Reset color to default
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  ____  _               ____             _      ");
            Console.WriteLine(" |  _ \\(_) ___ ___ ___|  _ \\ ___  _ __ | | ___ ");
            Console.WriteLine(" | | | | |/ __/ __/ _ \\ |_) / _ \\| '_ \\| |/ _ \\");
            Console.WriteLine(" | |_| | | (_| (_|  __/  __/ (_) | | | | |  __/");
            Console.WriteLine(" |____/|_|\\___\\___\\___|_|   \\___/|_| |_|_|\\___|");
            Console.WriteLine("");
            Console.WriteLine("                 YNOV CAMPUS CASABLANCA             ");
            Console.WriteLine("\n=======================================================\n");
            Console.WriteLine("           WELCOME TO SCHOOL MANAGEMENT SYSTEM             ");
            Console.WriteLine("\n=======================================================\n");
            Console.ResetColor(); // Reset color to default
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Press any key to continue...");
            Console.ResetColor(); // Reset color to default
            Console.ReadKey();
            Console.Clear();
            // Main menu
            MainMenu();
            // Thread.Sleep(2000);
            Console.Clear();
        }

        public static void MainMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=======================================================\n");
                Console.WriteLine("                   MAIN MENU\n");
                Console.WriteLine("=======================================================\n");
                Console.WriteLine("1. Login (ONLY USERS ACCESS !)\n");
                Console.WriteLine("2. Display Weekly Schedules For Students \n");
                Console.WriteLine("3. The Calendar \n");
                Console.WriteLine("4. Display Course Details\n");
                Console.WriteLine("5. Manage Users (ONLY ADMIN ACCESS !)\n");
                Console.WriteLine("6. Manage Students (ONLY ADMIN ACCESS !)\n");
                Console.WriteLine("7. Manage Teachers (ONLY ADMIN ACCESS !)\n");
                Console.WriteLine("8. Manage Administrators (ONLY ADMIN ACCESS !)\n");
                Console.WriteLine("9. Manage Courses (ONLY ADMIN ACCESS !)\n");
                Console.WriteLine("10. Manage Modules (ONLY ADMIN ACCESS !)\n");
                Console.WriteLine("11. Logout \n");
                Console.WriteLine("12. Exit\n");
                Console.ResetColor(); // Reset color to default
                Console.Write("Enter your choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Login.LoginUser();
                            break;

                        case 2:
                            Administrator.ViewStudentSchedule();
                            break;

                        case 3:
                            Administrator.ViewCalendar();
                            break;

                        case 4:
                            if (Course.CoursePath != null)
                            {
                                Course.DisplayCourseDetails(Course.CoursePath);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nCourse path is null !\n");
                                Console.ResetColor();
                            }
                            break;

                        case 5:
                            User.ManageUsers();
                            break;

                        case 6:
                            Student.ManageStudents();
                            break;

                        case 7:
                            Teacher.ManageTeachers();
                            break;

                        case 8:
                            Administrator.ManageAdministration();
                            break;

                        case 9:
                            Course.ManageCourses();
                            break;

                        case 10: 
                            Module.ManageModules();
                            break;

                        case 11:
#pragma warning disable CS8604 // Possible null reference argument.
                            Login.LogoutUser(Login.CurrentUser);
#pragma warning restore CS8604 // Possible null reference argument.
                            break;

                        case 12:
                            exit = true;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\nTHANK YOU FOR USING OUR CONSOLE APP. GOODBYE !\n");
                            Console.WriteLine("  _______ _                 _     ");
                            Console.WriteLine(" |__   __| |               | |    ");
                            Console.WriteLine("    | |  | |__   __ _ _ __ | | __ ");
                            Console.WriteLine("    | |  | '_ \\ / _` | '_ \\| |/ / ");
                            Console.WriteLine("    | |  | | | | (_| | | | |   <  ");
                            Console.WriteLine("    |_|  |_| |_|\\__,_|_| |_|_|\\_\\ ");
                            Console.WriteLine();
                            Console.WriteLine("     YOU FOR USING OUR CONSOLE APP ! ");
                            Console.WriteLine();
                            Console.WriteLine("                GOODBYE !            ");
                            Console.WriteLine();
                            Console.ResetColor();
                            Environment.Exit(0);
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice ! Try again.\n");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid input ! Please enter a valid number.\n");
                    Console.ResetColor();
                    continue;
                }
            }
        }
    }
}
