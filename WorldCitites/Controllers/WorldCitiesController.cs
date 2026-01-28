using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldCitites.Data;
using WorldCitites.Models;

namespace WorldCitites.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorldCitiesController : ControllerBase
    {
        private readonly WorldCitiesContext _context;

        public WorldCitiesController(WorldCitiesContext context)
        {
            _context = context;
        }

        // GET: api/WorldCities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorldCity>>> GetWorldCities()
        {
            return await _context.WorldCities
                .OrderByDescending(c  => c.Population)
                .ToListAsync();
        }

        // GET: api/WorldCities/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WorldCity>> GetWorldCity(int id)
        {
            var worldCity = await _context.WorldCities.FindAsync(id);

            if (worldCity == null)
            {
                return NotFound();
            }

            return worldCity;
        }
        
        // POST: api/WorldCities
        [HttpPost]
        public async Task<ActionResult<WorldCity>> PostWorldCity(WorldCityCreateDto worldCityDto)
        {
            var worldCity = new WorldCity
            {
                City = worldCityDto.City,
                Country = worldCityDto.Country,
                Population = worldCityDto.Population
            };

            _context.WorldCities.Add(worldCity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorldCity", new { id = worldCity.CityId }, worldCity);
        }

        // POST as PUT(or PATCH): api/WorldCities/{id}/update, allows partial updates via query parameters
        [HttpPost("{id}/update")]
        [Route("{id}/update")]
        public async Task<IActionResult> UpdateWorldCity(int id, [FromQuery] WorldCityUpdateDto worldCityDto)
        {
            var worldCity = await _context.WorldCities.FindAsync(id);

            if (worldCity == null) return NotFound();

            if (!string.IsNullOrWhiteSpace(worldCityDto.City)) worldCity.City = worldCityDto.City;
            if (!string.IsNullOrWhiteSpace(worldCityDto.Country)) worldCity.Country = worldCityDto.Country;
            if (worldCityDto.Population.HasValue) worldCity.Population = worldCityDto.Population.Value;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorldCityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST as DELETE: api/WorldCities/{id}/delete
        [HttpPost("{id}/delete")]
        [Route("{id}/delete")]
        public async Task<IActionResult> DeleteWorldCity(int id)
        {
            var worldCity = await _context.WorldCities.FindAsync(id);
            if (worldCity == null)
            {
                return NotFound();
            }

            _context.WorldCities.Remove(worldCity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorldCityExists(int id)
        {
            return _context.WorldCities.Any(e => e.CityId == id);
        }
    }
}
