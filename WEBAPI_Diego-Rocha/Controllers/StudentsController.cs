using Microsoft.AspNetCore.Mvc;
using WEBAPI_Diego_Rocha.Models;
using WEBAPI_Diego_Rocha.Repository;

namespace WEBAPI_Diego_Rocha.Controllers
{
    [Route("students")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly StudentsInMemory repository;

        public StudentsController() 
        {
            repository = new StudentsInMemory();
        }

        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            var StudentsList = repository.getStudents();
            return StudentsList;
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var item = repository.GetStudent(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}
