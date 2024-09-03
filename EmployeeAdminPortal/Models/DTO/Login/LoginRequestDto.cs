using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Models.DTO.Login
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
