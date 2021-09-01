using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STUDENTPORTAL.Models;

namespace STUDENTPORTAL.Helpers
{
    public class StudentRepository
    {
        //private Field
        private List<StudentInformation> _studentList;
        public StudentRepository()
        {
            _studentList = new List<StudentInformation>()
            {
                new StudentInformation() {StudentId = 1, FirstName = "Victory", Email = "olorunfemivictory22@gmail.com"},
                new StudentInformation() {StudentId = 2, FirstName = "Comfort", Email = "olorunfemicomfort20@gmail.com"}
            };
        }
        public StudentInformation Add(StudentInformation student)
        {
            student.StudentId = _studentList.Max(e => e.StudentId) + 1;
            _studentList.Add(student);
            return student;
        }

        public IEnumerable<StudentInformation> GetAllStudent()
        {
            return _studentList;
        }

        public StudentInformation GetStudent(int Id)
        {
            //StudentInformation student = new StudentInformation();
            //return student;
            return _studentList.FirstOrDefault(e => e.StudentId == Id);
        }
        public void Save(StudentInformation student)
        {

        }
    }

}
