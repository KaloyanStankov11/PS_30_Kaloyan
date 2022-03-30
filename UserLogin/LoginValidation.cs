using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        private string username;
        private string password;
        private string errorMsg;

        public static string currentUserName { get; private set; }
        public static UserRoles currentUserRole { get; private set; }
        public delegate void ActionOnError(string errorMsg);
        private ActionOnError error;

        public LoginValidation(string user, string password, ActionOnError error)
        {
            this.username = user;
            this.password = password;
            this.error = error;
        }
        public bool ValidateUserInput(ref User u)
        {
      
            Boolean emptyUsername, emptyPassword, shortUsername = false, shortPassword = false;
            emptyUsername = username.Equals(String.Empty);
            emptyPassword = password.Equals(String.Empty);
            if (this.username.Length < 5) { shortUsername = true; }
            if (this.password.Length < 5) { shortPassword = true; }
            if (emptyUsername && emptyPassword)
            {
                Console.WriteLine("Username or password not set!");
                error(errorMsg);
                return false;
            }
            if (shortUsername || shortPassword)
            {
                Console.WriteLine("Username or password shorter than 5 symbols!");
                error(errorMsg);
                return false;
            }

            User newU = new User();
            newU = UserData.IsUserPassCorrect(username, password);

            if(newU != null)
            {
                u = newU;
                currentUserRole = u.role;
            }
            else
            {
                currentUserRole = UserRoles.ANONYMOUS;
                errorMsg = "Incorrect user!";
                error(errorMsg);
                return false;
            }

            currentUserName = this.username;
            Logger.LogActivity("Successfull Login");
            return true;
        }
    }
}
