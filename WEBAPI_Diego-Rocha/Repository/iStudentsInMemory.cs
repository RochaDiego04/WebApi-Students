using WEBAPI_Diego_Rocha.Models;

namespace WEBAPI_Diego_Rocha.Repository
{
    public interface iStudentsInMemory
    {
        public IEnumerable<Student> getStudents();
        Student GetStudent(int id);
    }
}
