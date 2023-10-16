using WEBAPI_Diego_Rocha.Models;

namespace WEBAPI_Diego_Rocha.Repository
{
    public class StudentsInMemory
    {
        private readonly List<Student> students = new()
        {
            new Student { Id = 1, Name = "Diego", Age = 20, EnrollmentNumber = "21310423", EnrollmentDate = DateTime.Now},
            new Student { Id = 2, Name = "Juan", Age = 22, EnrollmentNumber = "21310429", EnrollmentDate = DateTime.Now},
            new Student { Id = 3, Name = "Alan", Age = 18, EnrollmentNumber = "21310439", EnrollmentDate = DateTime.Now}
        };

        public IEnumerable<Student> getStudents()
        {  
           return students; 
        } 

        public Student GetStudent(int id)
        { return students.Where(p => p.Id == id).SingleOrDefault(); }
    }
}
