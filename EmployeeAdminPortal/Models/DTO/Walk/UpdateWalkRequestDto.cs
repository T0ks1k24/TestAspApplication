using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Models.DTO.Walk
{
    public class UpdateWalkRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Max length 255")]
        [MinLength(30, ErrorMessage = "Min length 30")]
        public string Description { get; set; }

        [Required]
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
