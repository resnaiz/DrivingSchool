using System;
using System.Collections.Generic;
using DrivingSchool.Models;
using System.Threading.Tasks;
using DrivingSchool.Interfaces;
using System.Net.Mail;
using System.Net;
using System.Runtime.CompilerServices;

namespace DrivingSchool.Services
{
    public class StudentService : EntityService<Student>, IStudentService
    {
        public StudentService(IDrivingSchoolDbContext context) : base(context)
        {
        }

        public Student GetById(int id)
        {
            return GetById<Student>(id);
        }

        public void Add(Student entity)
        {
            Add<Student>(entity);
        }

        public void SetExam(int id, string exam, DateTime date)
        {
            var student = GetById<Student>(id);

            switch (exam)
            {
                case "theory":
                    student.DateOfTheoryExam = date;
                    student.UniqueCodeForTheoryExam = Guid.NewGuid().ToString();
                    break;
                case "driving":
                    student.DateOfDrivingExam = date;
                    student.UniqueCodeForDrivingExam = Guid.NewGuid().ToString();
                    break;
                default:
                    throw new Exception("Incorrect data received");
            }

            Update<Student>(student);
        }

        public void Delete(int id)
        {
            Delete<Student>(id);
        }

        public void EditMarks(int id, string markTitle, int mark)
        {
            var entity = GetById<Student>(id);

            switch (markTitle)
            {
                case "theory":
                    entity.TheoryMark = mark;
                    break;
                case "driving":
                    entity.DrivingMark = mark;
                    break;
            }

            Update(entity);
        }

        public List<Student> GetAll()
        {
            return GetAll<Student>();
        }

        public async Task SendEmail(int id, string exam)
        {
            try
            {
                var student = GetById(id);
                var receiver = student.EmailAddress;

                var newMail = new MailMessage
                {
                    From = new MailAddress("drivingschool@gmail.com"),
                    To = { receiver },
                    Subject = exam switch
                    {
                        "theory" => $"Theory exam for {student.FirstName} {student.LastName}",
                        "driving" => $"Driving exam for {student.FirstName} {student.LastName}",
                        _ => throw new InvalidOperationException("Invalid examTitle"),
                    },
                    Body = exam switch
                    {
                        "theory" => $"Your theory exam is scheduled for {student.DateOfTheoryExam}, " +
                                    $"Your unique code: {student.UniqueCodeForTheoryExam}",
                        "driving" => $"Your driving exam is scheduled for {student.DateOfDrivingExam}, " +
                                     $"Your unique code: {student.UniqueCodeForDrivingExam}",
                        _ => throw new InvalidOperationException("Invalid examTitle"),
                    },
                    IsBodyHtml = true
                };

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("drivingschool@gmail.com", "passwordNew32@2")
                };

                await client.SendMailAsync(newMail);
                Console.WriteLine("Email sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}