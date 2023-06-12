using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DrivingSchool.Models;

namespace DrivingSchool.Interfaces
{
    public interface IStudentService : IEntityService<Student>
    {
        Student GetById(int id);
        void Add(Student entity);
        void SetExam(int id, string exam, DateTime date);
        void Delete(int id);
        void EditMarks(int id, string markTitle, int mark);
        List<Student> GetAll();
        Task SendEmail(int id, string exam);
    }
}
