using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusManagement.Data;
using BusManagement.Models;

namespace BusManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Regions
        [HttpGet]
        [Route("GetAllRegions")]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
        {
            return await _context.Regions.ToListAsync();
        }

        // GET: api/Regions/5
        [HttpGet("GetRoutesById/{id}")]
        public async Task<ActionResult<Region>> GetRegionById(int id)
        {
            var region = await _context.Regions.FindAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return region;
        }

        // POST: api/Regions
        [HttpPost]
        [Route("InsertRegions")]

        public async Task<ActionResult<Region>> PostRegion(Region region)
        {
            _context.Regions.Add(region);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegionById", new { id = region.Id }, region);
        }

        // PUT: api/Regions/5
        [HttpPut("UpdateRegions/{id}")]
        public async Task<IActionResult> PutRegion(int id, Region region)
        {
            if (id != region.Id)
            {
                return BadRequest();
            }

            _context.Entry(region).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(id))
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

        // DELETE: api/Regions/5
        [HttpDelete("DeleteRegionsById/{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            var region = await _context.Regions.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegionExists(int id)
        {
            return _context.Regions.Any(e => e.Id == id);
        }
    }
}
