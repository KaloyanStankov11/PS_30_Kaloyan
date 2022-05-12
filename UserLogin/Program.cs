using System;
using System.Text;
using System.Collections.Generic;

namespace UserLogin {
    class Program {
        public static void ActionOnError(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }

        static LoginDetails PrintLogin(string error = "")
        {
            Console.Clear();
            int x = Console.WindowWidth / 2;
            int y = Console.WindowHeight / 2;
            Console.SetCursorPosition(x - 8, y - 2);
            Console.WriteLine("Enter Username: ");
            Console.SetCursorPosition(x - 8, y - 2 + 1);
            Console.WriteLine("________________");

            Console.SetCursorPosition(x - 8, y - 2 + 2);
            Console.WriteLine("Enter Password: ");
            Console.SetCursorPosition(x - 8, y - 2 + 3);
            Console.WriteLine("________________");
            if (string.IsNullOrEmpty(error))
            {
                Console.SetCursorPosition(x - 8, y - 2 + 1);
                Console.WriteLine("________________");
                Console.SetCursorPosition(x - 8, y - 2 + 3);
                Console.WriteLine("________________");
                Console.SetCursorPosition(x - 8, y - 2 + 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.SetCursorPosition(x - 8, y - 2 + 1);
            string userName = Console.ReadLine();
            Console.SetCursorPosition(x - 8, y - 2 + 3);
            string pass = Console.ReadLine();

            LoginDetails details = new LoginDetails(userName, pass);
            return details;
        }

        static void Main(string[] args) {
            var login = PrintLogin("Wrong details");
            Console.WriteLine();

            LoginValidation validator = new LoginValidation(login.username, login.password, ActionOnError);

            User user = null;

            if (validator.ValidateUserInput(ref user))
            {
                Console.WriteLine("Name: " + user.userName);
                Console.WriteLine("Pass: " + user.password);
                Console.WriteLine("Fac Num: " + user.facNumber);
                Console.WriteLine("Role: " + user.role);
                
                switch (Convert.ToInt32(LoginValidation.currentUserRole))
                {
                    case 0:
                        Console.WriteLine("Ролята на потребителя е: Анонимен");
                        break;
                    case 1:
                        Console.WriteLine("Ролята на потребителя е: Админ");
                        
                        Boolean displayMenu = true;
                        while (displayMenu)
                        {
                            Console.Clear();
                            displayMenu = displayAdminMenu();
                        }
                        
                        break;
                    case 2:
                        Console.WriteLine("Ролята на потребителя е: Инспектор");
                        break;
                    case 3:
                        Console.WriteLine("Ролята на потребителя е: Професор");
                        break;
                    case 4:
                        Console.WriteLine("Ролята на потребителя е: Студент");
                        break;
                }
            }
            Console.ReadKey();
        }

        private static Boolean displayAdminMenu()
        {
            string userName;
            int x = Console.WindowWidth / 2;
            int y = Console.WindowHeight / 2;
            Console.SetCursorPosition(x - 18, y-5);
            Console.WriteLine("Меню ___");
            Console.SetCursorPosition(x - 18, y - 5 + 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0: Изход");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(x - 18, y - 5 + 2);
            Console.WriteLine("1: Промяна на роля на потребител");
            Console.SetCursorPosition(x - 18, y - 5 + 3);
            Console.WriteLine("2: Промяна на активност на потребител");
            Console.SetCursorPosition(x - 18, y - 5 + 4);
            Console.WriteLine("3: Списък на потребителите");
            Console.SetCursorPosition(x - 18, y - 5 + 5);
            Console.WriteLine("4: Преглед на лог на активност");
            Console.SetCursorPosition(x - 18, y - 5 + 6);
            Console.WriteLine("5: Преглед на текуща активност");
            Console.SetCursorPosition(x - 18, y - 5 + 8);
            Console.Write("Изберете опция: ");
            var option = Console.ReadLine();
            switch (option)
            {
                
                case "0" :
                    return false;
                case "1":
                    Console.SetCursorPosition(x - 18 + 6, y - 5);
                    Console.Write(option);
                    Console.SetCursorPosition(x - 18, y - 5 + 2);
                    Console.ForegroundColor= ConsoleColor.Cyan;
                    Console.WriteLine("1: Промяна на роля на потребител");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                    Console.Write("\r\nВъведете потребителско име на потребителя който искате да редактирате: ");
                    userName = Console.ReadLine();

                    Console.Write("\r\nВъведете новата роля: ");
                    UserRoles role = (UserRoles)Convert.ToInt32(Console.ReadLine());

                    UserData.AssignUserRole(userName, role);

                    return true;
                case "2":
                    Console.Write("\r\nВъведете потребителско име на потребителя който искате да редактирате: ");
                    userName = Console.ReadLine();

                    Console.Write("\r\nВъведете новата дата: ");
                    DateTime date = Convert.ToDateTime(Console.ReadLine());

                    UserData.SetUserActiveTo(userName, date);

                    return true;
                case "3":
                    UserData.seeAllUsers();
                    return true;
                case "4":
                    IEnumerable<string> logs = Logger.GetLogsFromFile();
                    StringBuilder sb = new StringBuilder();

                    foreach(string log in logs)
                    {
                        sb.Append(log).Append(Environment.NewLine);
                    }
                    
                    Console.WriteLine(sb.ToString());
                    return true;
                case "5":
                    Console.Write("\nВеведете филтър: ");
                    string filter = Console.ReadLine();
                    
                    StringBuilder builder = new StringBuilder();
                    IEnumerable<string> currentActs = Logger.GetCurrentSessionActivities(filter);

                    foreach (string message in currentActs)
                    {
                        builder.Append(message).Append(Environment.NewLine);
                    }

                    Console.Write(builder.ToString());
                    return true;
                default:
                    return true;
            }
        }
    }
}

