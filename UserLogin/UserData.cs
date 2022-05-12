using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        static private List<User> _testUsers;
        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        private static void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>();

                User firstUser = new User();
                firstUser.userName = "qwerty";
                firstUser.password = "123456";
                firstUser.facNumber = "121219456";
                firstUser.role = 4;
                firstUser.created = DateTime.Now;
                firstUser.activeUntil = DateTime.MaxValue;

                _testUsers.Add(firstUser);

                User secondUser = new User();
                secondUser.userName = "Second Student";
                secondUser.password = "Second pass";
                secondUser.facNumber = "654321";
                secondUser.role = 4;
                secondUser.created = DateTime.Now;
                secondUser.activeUntil = DateTime.MaxValue;

                _testUsers.Add(secondUser);

                User adminUser = new User();
                adminUser.userName = "Admin";
                adminUser.password = "Admin pass";
                adminUser.facNumber = "65432198";
                adminUser.role = 1;
                adminUser.created = DateTime.Now;
                adminUser.activeUntil = DateTime.MaxValue;

                _testUsers.Add(adminUser);
            }
        }

        public static User IsUserPassCorrect(string userName, string pass)
        {
            User user = (from u in TestUsers
                         where u.userName.Equals(userName) && u.password.Equals(pass)
                         select u).FirstOrDefault();

            return user;
        }

        public static void SetUserActiveTo(string userName, DateTime newDate)
        {
            foreach (User user in TestUsers)
            {
                if (user.userName.Equals(userName))
                {
                    user.activeUntil = newDate;
                }
            }

            Logger.LogActivity("Промяна на активност на " + userName);
        }

        public static void AssignUserRole(string userName, UserRoles role)
        {
            foreach (User user in TestUsers)
            {
                if (user.userName.Equals(userName))
                {
                    user.role = Convert.ToInt32(role);
                }
            }

            Logger.LogActivity("Промяна на роля на " + userName);
        }

        public static void seeAllUsers()
        {
            foreach (User user in _testUsers)
            {
                Console.WriteLine(user.userName);
            }
        }
    }
}
