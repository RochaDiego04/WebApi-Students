﻿using Microsoft.AspNetCore.Mvc;
using WEBAPI_Diego_Rocha.DTO;
using WEBAPI_Diego_Rocha.Models;
using WEBAPI_Diego_Rocha.Repository;

namespace WEBAPI_Diego_Rocha.Controllers
{
    [Route("students")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly iStudentsInMemory repository;

        public StudentsController(iStudentsInMemory r) 
        {
            this.repository = r;
        }

        [HttpGet]
        public IEnumerable<StudentDTO> GetStudents()
        {
            var StudentsList = repository.GetStudents().Select(s=>s.transformToDTO());
            return StudentsList;
        }

        [HttpGet("{enrollmentNumber}")]
        public ActionResult<StudentDTO> GetStudent(string enrollmentNumber)
        {
            var item = repository.GetStudent(enrollmentNumber).transformToDTO();
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<StudentDTO> CreateStudent(StudentDTO s)
        {
            Student student = new Student
            {
                Id = repository.GetStudents().Max(x => x.Id) + 1, //Get the last id
                Name = s.Name,
                Age = s.Age,
                EnrollmentDate = DateTime.Now,
                EnrollmentNumber = s.EnrollmentNumber,
            };
            repository.CreateStudent(student);
            return student.transformToDTO();
        }

        [HttpPut]
        public ActionResult<StudentDTO> UpdateStudent(string studentEnrollmentNumber, UpdateStudentDTO s)
        {
            Student studentExists = repository.GetStudent(studentEnrollmentNumber);
            if (studentExists is null)
            {
                return NotFound();
            }

            studentExists.Name = s.Name;
            studentExists.Age = s.Age;

            repository.UpdateStudent(studentExists);

            return studentExists.transformToDTO();
        }

        [HttpDelete]
        public ActionResult DeleteStudent(string studentEnrollmentNumber)
        {
            Student studentExists = repository.GetStudent(studentEnrollmentNumber);
            if (studentExists is null)
            {
                return NotFound();
            }
            repository.DeleteStudent(studentEnrollmentNumber);
            return NoContent();
        }
    }
}
