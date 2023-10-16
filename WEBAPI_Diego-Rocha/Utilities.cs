using WEBAPI_Diego_Rocha.DTO;
using WEBAPI_Diego_Rocha.Models;

namespace WEBAPI_Diego_Rocha
{
    public static class Utilities
    {
        public static StudentDTO transformToDTO(this Student student)
        {
            if(student != null)
            {
                return new StudentDTO
                {
                    Name = student.Name,
                    Age = student.Age,
                    EnrollmentNumber = student.EnrollmentNumber
                };
            }
            return null;
        }
    }
}
