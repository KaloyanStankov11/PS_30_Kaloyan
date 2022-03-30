using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal static class StudentData
    {
        public static List<Student> testStudents { get; private set; }

        static StudentData()
        {
            testStudents = new List<Student>();
            Student student1 = new Student();
            student1.name = "Иван";
            student1.forename = "Иванов";
            student1.surname = "Иванов";
            student1.faculty = "ФКСТ";
            student1.specialty = "КСИ";
            student1.degree = "Бакалавър";
            student1.status = "Заверил";
            student1.fNum = 121219777;
            student1.course = 3;
            student1.potok = 9;
            student1.group = 30;
            testStudents.Add(student1);
        }
    }
}
