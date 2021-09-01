using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STUDENTPORTAL.Models;

namespace STUDENTPORTAL.Repository
{
   public interface IStudentRepository
    {
        StudentInformation GetStudent(int Id);
        void Save(StudentInformation student);
        IEnumerable<StudentInformation> GetAllStudent();
        StudentInformation Add(StudentInformation student);
    }
}
