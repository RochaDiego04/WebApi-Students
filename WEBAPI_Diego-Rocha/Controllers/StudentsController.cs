using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<StudentDTO>> GetStudents()
        {
            var StudentsList = (await repository.AsyncGetStudents()).Select(s=>s.transformToDTO());
            return StudentsList;
        }

        [HttpGet("{enrollmentNumber}")]
        public async Task<ActionResult<StudentDTO>> GetStudent(string enrollmentNumber)
        {
            var item = (await repository.AsyncGetStudent(enrollmentNumber)).transformToDTO();
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<StudentDTO>> CreateStudent(StudentDTO s)
        {
            Student student = new Student
            {
                Name = s.Name,
                Age = s.Age,
                EnrollmentDate = DateTime.Now,
                EnrollmentNumber = s.EnrollmentNumber,
            };
            await repository.AsyncCreateStudent(student);
            return student.transformToDTO();
        }

        [HttpPut]
        public async Task<ActionResult<StudentDTO>> UpdateStudent(string studentEnrollmentNumber, UpdateStudentDTO s)
        {
            Student studentExists = await repository.AsyncGetStudent(studentEnrollmentNumber);
            if (studentExists is null)
            {
                return NotFound();
            }

            studentExists.Name = s.Name;
            studentExists.Age = s.Age;

            await repository.AsyncUpdateStudent(studentExists);

            return studentExists.transformToDTO();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteStudent(string studentEnrollmentNumber)
        {
            Student studentExists = await repository.AsyncGetStudent(studentEnrollmentNumber);
            if (studentExists is null)
            {
                return NotFound();
            }
            await repository.AsyncDeleteStudent(studentEnrollmentNumber);
            return NoContent();
        }
    }
}
