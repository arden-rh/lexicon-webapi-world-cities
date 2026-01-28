using System.ComponentModel.DataAnnotations;

/* World City DTOs: Data Transfer Objects */

namespace WorldCitites
{
    public class WorldCityBaseDto
    {
        public string? City { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Population must be a non-negative integer.")]

        public int? Population { get; set; }
    }

    public class WorldCityCreateDto : WorldCityBaseDto 
    {
        [Required(ErrorMessage = "City is required.")]
        public new string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        public new string Country { get; set; } = string.Empty;

        [Required]
        public new int Population { get; set; }
    }

    public class WorldCityUpdateDto : WorldCityBaseDto { }
}
