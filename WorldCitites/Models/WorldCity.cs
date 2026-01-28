using System.ComponentModel.DataAnnotations;

namespace WorldCitites.Models
{
    public class WorldCity
    {
        [Key]
        public int CityId { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Population must be a non-negative integer.")]
        public int Population { get; set; } = 0;

    }
}
