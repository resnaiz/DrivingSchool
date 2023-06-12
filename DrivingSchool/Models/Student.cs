using System;

namespace DrivingSchool.Models
{
    public class Student : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string TrainingCategory { get; set; }
        public DateTime? DateOfTheoryExam { get; set; }
        public DateTime? DateOfDrivingExam { get; set; }
        public int? TheoryMark { get; set; }
        public int? DrivingMark { get; set; }
        public string? UniqueCodeForTheoryExam { get; set; }
        public string? UniqueCodeForDrivingExam { get; set; }
    }
}
