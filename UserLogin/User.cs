using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int fNum { get; set; }
        public UserRoles role { get; set; }
        public DateTime Created { get; set; }
        public DateTime ValidThru { get; set; }
    }
}
