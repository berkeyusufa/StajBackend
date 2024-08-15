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
    public class BusRoutesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BusRoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BusRoutes
        [HttpGet]
        [Route("GetAllBusRoutes")]
        public async Task<ActionResult<IEnumerable<BusRoute>>> GetBusRoutes()
        {
            var a=await _context.BusRoutes.ToListAsync();
            return await _context.BusRoutes.ToListAsync();
        }

        // GET: api/BusRoutes/5
        [HttpGet("GetBusRouteById/{id}")]
        public async Task<ActionResult<BusRoute>> GetBusRouteById(int id)
        {
            var busRoute = await _context.BusRoutes.FindAsync(id);

            if (busRoute == null)
            {
                return NotFound();
            }

            return busRoute;
        }

        // POST: api/BusRoutes
        [HttpPost]
        [Route("InsertBusRoute")]
        public async Task<ActionResult<BusRoute>> PostBusRoute(BusRoute busRoute)
        {
            _context.BusRoutes.Add(busRoute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusRouteById", new { id = busRoute.Id }, busRoute);
        }

        // PUT: api/BusRoutes/5
        [HttpPut("UpdateBusRoute/{id}")]
        public async Task<IActionResult> PutBusRoute(int id, BusRoute busRoute)
        {
            if (id != busRoute.Id)
            {
                return BadRequest();
            }

            _context.Entry(busRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusRouteExists(id))
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

        // DELETE: api/BusRoutes/5
        [HttpDelete("DeleteBusRouteById/{id}")]
        public async Task<IActionResult> DeleteBusRoute(int id)
        {
            var busRoute = await _context.BusRoutes.FindAsync(id);
            if (busRoute == null)
            {
                return NotFound();
            }

            _context.BusRoutes.Remove(busRoute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusRouteExists(int id)
        {
            return _context.BusRoutes.Any(e => e.Id == id);
        }
    }
}
