using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    internal class StudentValidation
    {
        public Student getStudentDataByUser(User user)
        {
            foreach(Student s in StudentData.testStudents)
            {
                if(user.fNum == s.fNum) { return s; }
            }
            return null;
        }
    }
}
