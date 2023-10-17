using WEBAPI_Diego_Rocha.Models;

namespace WEBAPI_Diego_Rocha.Repository
{
    public interface iStudentsInMemory
    {
        Task<IEnumerable<Student>> AsyncGetStudents();

        Task<Student> AsyncGetStudent(string enrollmentNumber);

        Task AsyncCreateStudent(Student student);

        Task AsyncUpdateStudent(Student student);

        Task AsyncDeleteStudent(string enrollmentNumber);
    }
}
