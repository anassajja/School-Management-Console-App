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
            string soundPath = @"\Music\DrDre.wav";
            // Use the SND_ASYNC flag to play the sound asynchronously
            uint flags = 0x1 | 0x2;
            // Call PlaySound function
            PlaySound(soundPath, IntPtr.Zero, flags);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("          Enjoy Listening DR DRE Music          ");
            Console.ResetColor(); // Reset color to default
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  ____  _               ____             _      ");
            Console.WriteLine(" |  _ \\(_) ___ ___ ___|  _ \\ ___  _ __ | | ___ ");
            Console.WriteLine(" | | | | |/ __/ __/ _ \\ |_) / _ \\| '_ \\| |/ _ \\");
            Console.WriteLine(" | |_| | | (_| (_|  __/  __/ (_) | | | | |  __/");
            Console.WriteLine(" |____/|_|\\___\\___\\___|_|   \\___/|_| |_|_|\\___|");
            Console.WriteLine("");
            Console.WriteLine("                 YNOV CAMPUS CASABLANCA             ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=======================================================\n");
            Console.WriteLine("           WELCOME TO SCHOOL MANAGEMENT SYSTEM             ");
            Console.WriteLine("\n=======================================================\n");
            Console.ResetColor(); // Reset color to default

            bool exit = false;

            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Login < ONLY FOR USERS! >\n");
                Console.WriteLine("2. Display Weekly Schedules For Students \n");
                Console.WriteLine("3. The Calendar \n");
                Console.WriteLine("4. Display Course Details\n");
                Console.WriteLine("5. Manage Users < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("6. Manage Students < ONLY ADMIN ACCESS ! > \n");
                Console.WriteLine("7. Manage Teachers < ONLY ADMIN ACCESS ! >\n");
                Console.WriteLine("8. Manage Administrators < ONLY ADMIN ACESS ! >\n");
                Console.WriteLine("9. Manage Courses< ONLY ADMIN & TEACHERS ACCESS ! >\n");
                Console.WriteLine("10. Manage Modules < ONLY ADMIN & TEACHERS ACCESS ! >\n");
                Console.WriteLine("11. Exit\n");
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
                                Console.WriteLine("\nCourse path is null.\n");
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
                            exit = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nThank you for using our application. Goodbye!\n");
                            Console.ResetColor();
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice. Try again.\n");
                            Console.ResetColor();
                            break;
                    }
                }

                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number.\n");
                    Console.ResetColor();
                    continue;
                }
            }
        }
    }
}
