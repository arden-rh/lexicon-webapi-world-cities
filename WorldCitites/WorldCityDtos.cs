using System.ComponentModel.DataAnnotations;

/* World City DTOs: Data Transfer Objects */

namespace WorldCitites
{
    public class WorldCityBaseDto
    {
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Population must be a non-negative integer.")]

        public int Population { get; set; }
    }

    // Testing the pattern for future projects that is bigger
    public class WorldCityCreateDto : WorldCityBaseDto { }
    public class WorldCityUpdateDto : WorldCityBaseDto { }
}
