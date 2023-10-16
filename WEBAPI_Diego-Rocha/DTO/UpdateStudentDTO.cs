using System.ComponentModel.DataAnnotations;

namespace WEBAPI_Diego_Rocha.DTO
{
    public class UpdateStudentDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
