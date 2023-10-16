﻿using WEBAPI_Diego_Rocha.Models;

namespace WEBAPI_Diego_Rocha.Repository
{
    public interface iStudentsInMemory
    {
        public IEnumerable<Student> GetStudents();

        Student GetStudent(string enrollmentNumber);

        void CreateStudent(Student student);
    }
}
