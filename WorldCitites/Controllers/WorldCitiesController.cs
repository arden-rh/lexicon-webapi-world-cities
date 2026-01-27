using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorldCitites.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorldCitiesController : ControllerBase
    {
        private static readonly List<WorldCity> SampleCities = new List<WorldCity>
        {
            new WorldCity { CityId = 1, City = "New York", Country = "USA", Population = 8419600 },
            new WorldCity { CityId = 2, City = "Tokyo", Country = "Japan", Population = 13929286 },
            new WorldCity { CityId = 3, City = "London", Country = "UK", Population = 8982000 },
        };


        // GET: api/<WorldCitiesController>
        [HttpGet]
        public IEnumerable<WorldCity> Get()
        {
            return SampleCities;
        }

        // GET api/<WorldCitiesController>/5
        [HttpGet("{id}")]
        public ActionResult<WorldCity> Get([FromRoute] int id)
        {
            var city = SampleCities.FirstOrDefault(c => c.CityId == id);

            return city;
        }

        // POST api/<WorldCitiesController>
        [HttpPost]
        public ActionResult<WorldCity> Post([FromBody] WorldCity newCity)
        {
            newCity.CityId = SampleCities.Max(c => c.CityId) + 1;
            SampleCities.Add(newCity);
            return CreatedAtAction(nameof(Get), new { id = newCity.CityId }, newCity);
        }

        // PUT api/<WorldCitiesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WorldCity updatedCity)
        {
            var existingCity = SampleCities.FirstOrDefault(c => c.CityId == id);
            if (existingCity == null) 
            {
                return NotFound($"City with ID {id} not found.");
            }
            existingCity.City = updatedCity.City;
            existingCity.Country = updatedCity.Country;
            existingCity.Population = updatedCity.Population;

            return NoContent();
        }

        // DELETE api/<WorldCitiesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCity = SampleCities.FirstOrDefault(c => c.CityId == id);
            if (existingCity == null) 
            {
                return NotFound($"City with ID {id} not found.");
            }
            SampleCities.Remove(existingCity);
            return NoContent();
        }
    }
}
