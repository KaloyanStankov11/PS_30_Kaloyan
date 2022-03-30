using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    class Program
    {

        static UserRoles intToUR(int i)
        {
            switch (i)
            {
                case 0:
                    return UserRoles.ANONYMOUS;
                case 1:
                    return UserRoles.ADMIN;
                case 2:
                    return UserRoles.INSPECTOR;
                case 3:
                    return UserRoles.PROFESSOR;
                case 4:
                    return UserRoles.STUDENT;
                default:
                    return UserRoles.ANONYMOUS;
            }
        }
        public static bool AdminMenu()
        {
            
            Console.WriteLine("Choose option:");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Change user role");
            Console.WriteLine("2: Change user active to");
            Console.WriteLine("3: Users list");
            Console.WriteLine("4: Show log activity");
            Console.WriteLine("5: Show current log activity");
            string name;
            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    Console.WriteLine("Enter username: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter new role");
                    int ur = int.Parse(Console.ReadLine());
                    UserRoles newRole = intToUR(ur);
                    UserData.AssignUserRole(name, newRole);
                    return true;
                case "2":
                    Console.WriteLine("Enter username: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter new date:");
                    DateTime dt = DateTime.Parse(Console.ReadLine());
                    UserData.SetUserActiveTo(name, dt);
                    return true;
                case "3":
                    UserData.showAllUsers();
                    return true;
                case "4":
                    IEnumerable<string> log = Logger.showLog();
                    foreach(string logItem in log)
                    {
                        Console.WriteLine(logItem);
                    }
                    return true;
                case "5":
                    Console.WriteLine("Enter filter: ");
                    string filter = Console.ReadLine();
                    IEnumerable<string> current = Logger.GetCurrentSessionActivities(filter);
                    StringBuilder sb = new StringBuilder();
                    foreach (string activity in current)
                    {
                        sb.Append(activity);
                    }
                    Console.WriteLine(sb.ToString());
                    return true;
                default:
                    Console.WriteLine("Invalid input!");
                    return true;
            }
        }
        static void errorAction(string err)
        {
            Console.WriteLine("!!!"+err+"!!!");
        }
        static void Main(string[] args)
        {
            User user = null;
            //List<User> users = new List<User>();
            //users = UserData.testUsers;
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            LoginValidation validation = new LoginValidation(username, password, errorAction);
            if (validation.ValidateUserInput(ref user))
            {
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Password);
                Console.WriteLine(user.fNum);
                Console.WriteLine(user.role);
            }

            switch (LoginValidation.currentUserRole)
            {
                case UserRoles.STUDENT: 
                    Console.WriteLine("Student");
                    break;
                case UserRoles.PROFESSOR:
                    Console.WriteLine("Professor");
                    break;
                case UserRoles.ADMIN:
                    Console.WriteLine("Admin");
                    Boolean displayMenu = true;
                    while (displayMenu)
                    {
                        displayMenu = AdminMenu();
                    }
                    break;
                case UserRoles.INSPECTOR:
                    Console.WriteLine("Inspector");
                    break;
                default: 
                    Console.WriteLine("Anonymous");
                    break;
            }
        }
    }
}
