﻿namespace WEBAPI_Diego_Rocha.Models
{
    public class Student
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime EnrollmentDate { get; init; }
        public string EnrollmentNumber { get; init; }

    }
}
