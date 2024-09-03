using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Models.DTO.Region
{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Code has to be a minimum of 5 characters")]
        [MaxLength(5, ErrorMessage = "Code has to be a maximum of 5 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 characters")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
