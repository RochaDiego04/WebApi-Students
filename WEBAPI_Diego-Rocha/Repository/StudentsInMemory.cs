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

        public async Task<IEnumerable<Student>> AsyncGetStudents()
        {  
           return await Task.FromResult(students); 
        } 

        public async Task<Student> AsyncGetStudent(string enrollmentNumber)
        { 
            return await Task.FromResult(students.Where(p => p.EnrollmentNumber == enrollmentNumber).SingleOrDefault()); 
        }

        public async Task AsyncCreateStudent(Student student)
        {
            students.Add(student);
            await Task.CompletedTask;
        }

        public async Task AsyncUpdateStudent(Student student)
        {
            int index = students.FindIndex(studentExists => studentExists.Id == student.Id);
            students[index] = student;
            await Task.CompletedTask;
        }

        public async Task AsyncDeleteStudent(string enrollmentNumber)
        {
            int index = students.FindIndex(studentExists => studentExists.EnrollmentNumber == enrollmentNumber);
            students.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
