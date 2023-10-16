namespace WEBAPI_Diego_Rocha.DTO
{
    public class StudentDTO
    {
        // Don't return the id to the client
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime EnrollmentDate { get; init; }
        public string EnrollmentNumber { get; init; }
    }
}
