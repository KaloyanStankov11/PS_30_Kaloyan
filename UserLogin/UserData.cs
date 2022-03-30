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
        public static List<User> testUsers
        {
            get {
                ResetTestUserData();
                return _testUsers; 
            }
            set {  }
        }
        private static void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>();
                _testUsers.Add(new User());
                _testUsers[0].Name = "admin";
                _testUsers[0].Password = "admin";
                _testUsers[0].fNum = 0;
                _testUsers[0].role = UserRoles.ADMIN;
                _testUsers[0].Created = DateTime.Now;
                _testUsers[0].ValidThru = DateTime.MaxValue;


                _testUsers.Add(new User());
                _testUsers[1].Name = "Student1";
                _testUsers[1].Password = "Student1";
                _testUsers[1].fNum = 0;
                _testUsers[1].role = UserRoles.STUDENT;
                _testUsers[1].Created = DateTime.Now;
                _testUsers[1].ValidThru = DateTime.MaxValue;


                _testUsers.Add(new User());
                _testUsers[2].Name = "Student2";
                _testUsers[2].Password = "Student2";
                _testUsers[2].fNum = 0;
                _testUsers[2].role = UserRoles.STUDENT;
                _testUsers[2].Created = DateTime.Now;
                _testUsers[2].ValidThru = DateTime.MaxValue;
            }
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            foreach(User u in testUsers)
            {
                if ((username == u.Name) && (password == u.Password))
                {
                    return u;
                }
            }
            return null;
        }

        public static void SetUserActiveTo(string username, DateTime activeTo)
        {
            foreach(User u in testUsers)
            {
                if(username == u.Name)
                {
                    u.ValidThru = activeTo;
                    Logger.LogActivity("Промяна на активност на " + username);
                }
            }
        }

        public static void AssignUserRole(string username, UserRoles ur)
        {
            foreach (User u in testUsers)
            {
                if (username == u.Name)
                {
                    u.role = ur;
                    Logger.LogActivity("Промяна на роля на " + username);
                }
            }
        }

        public static void showAllUsers()
        {
            foreach(User u in testUsers)
            {
                Console.WriteLine("Username: " + u.Name);
                Console.WriteLine("Faculty number: " + u.fNum);
                Console.WriteLine("Role: " + u.role);
                Console.WriteLine("Date created: " + u.Created);
                Console.WriteLine("Valid thru: " + u.ValidThru);
            }
        }
    }
}
