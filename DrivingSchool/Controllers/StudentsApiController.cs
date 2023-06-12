using System;
using DrivingSchool.Interfaces;
using DrivingSchool.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrivingSchool.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IValidation _validation;

        public StudentController(IStudentService studentService, IValidation validation)
        {
            _studentService = studentService;
            _validation = validation;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpPut]
        public IActionResult AddStudent(Student student)
        {
            _studentService.Add(student);
            return Ok(student);
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            if (!_validation.CheckId(id))
            {
                return BadRequest();
            }

            _studentService.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("students-mark")]
        public IActionResult EditMarker(int id, string markTitle, int mark)
        {
            if (!_validation.CheckMark(mark) || !_validation.CheckId(id) || !_validation.CheckTitle(markTitle))
            {
                return BadRequest();
            }

            _studentService.EditMarks(id, markTitle, mark);
            return Ok(_studentService.GetById(id));
        }

        [HttpPost]
        [Route("students-exam")]
        public IActionResult SetExam(int id, string exam, DateTime date)
        {
            if (!_validation.CheckId(id) || !_validation.CheckTitle(exam))
            {
                return BadRequest();
            }

            _studentService.SetExam(id, exam, date);
            return Ok(_studentService.GetById(id));
        }

        [HttpGet]
        [Route("students-email")]
        public IActionResult SendEmail(int id, string exam)
        {
            var send = _studentService.SendEmail(id, exam);
            return Ok();
        }
    }
}
