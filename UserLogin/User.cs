using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin {
    public class User {
        public string userName { get; set; }
        public string password { get; set; }
        public string facNumber { get; set; }
        public Int32 role { get; set; }
        public DateTime created { get; set; }
        public DateTime activeUntil { get; set; }
    }

    public class LoginDetails
    {
        public string username;
        public string password;

        public LoginDetails(string username, string password) {
            this.username = username;
            this.password = password;
        }
    }
}
