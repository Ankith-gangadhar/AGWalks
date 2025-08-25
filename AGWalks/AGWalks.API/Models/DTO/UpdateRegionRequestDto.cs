using System.ComponentModel.DataAnnotations;

namespace AGWalks.API.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to have 3 characters ")]
        [MaxLength(3, ErrorMessage = "Code cannot exceed 3 characters ")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot be more than 100 characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
