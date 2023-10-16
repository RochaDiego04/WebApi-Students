using System.ComponentModel.DataAnnotations;

namespace WEBAPI_Diego_Rocha.DTO
{
    public class StudentDTO
    {
        // Don't return the id to the client
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string EnrollmentNumber { get; init; }
    }
}
