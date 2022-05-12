using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class StudentData
    {
        private List<Student> TestStudents;

        public StudentData()
        {
            TestStudents = new List<Student>();
            TestStudents.Add(exampleStudent());
        }

        public List<Student> getStudents()
        {
            return this.TestStudents;
        }

        private void setStudents(List<Student> students)
        {
            this.TestStudents = students;
        }

        private Student exampleStudent()
        {
            Student student = new Student("Иван", "Петров", "Иванов", "ФКСТ", "КСИ", "Бакалавър", "Заверил",
                "121219456", 3, 9, 30);

            return student;
        }
    }
}
