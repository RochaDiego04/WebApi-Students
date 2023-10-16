using WEBAPI_Diego_Rocha.Models;

namespace WEBAPI_Diego_Rocha.Repository
{
    public class StudentsInMemory : iStudentsInMemory
    {
        private readonly List<Student> students = new()
        {
            new Student { Id = 1, Name = "Diego", Age = 20, EnrollmentDate = DateTime.Now, EnrollmentNumber = "21310423"},
            new Student { Id = 2, Name = "Juan", Age = 22, EnrollmentDate = DateTime.Now, EnrollmentNumber = "21310429"},
            new Student { Id = 3, Name = "Alan", Age = 18, EnrollmentDate = DateTime.Now, EnrollmentNumber = "21310439"}
        };

        public IEnumerable<Student> GetStudents()
        {  
           return students; 
        } 

        public Student GetStudent(string enrollmentNumber)
        { return students.Where(p => p.EnrollmentNumber == enrollmentNumber).SingleOrDefault(); }

        public void CreateStudent(Student student)
        {
            students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            int index = students.FindIndex(studentExists => studentExists.Id == student.Id);
            students[index] = student;
        }

        public void DeleteStudent(string enrollmentNumber)
        {
            int index = students.FindIndex(studentExists => studentExists.EnrollmentNumber == enrollmentNumber);
            students.RemoveAt(index);
        }
    }
}
