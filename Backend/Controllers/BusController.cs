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
    public class BusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BusController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllBuses")]
        public async Task<ActionResult<IEnumerable<Bus>>> GetAllBuses()
        {
            return await _context.Buses.Where(b => !b.IsDeleted).ToListAsync();
        }

        [HttpGet("GetBusById/{id}")]
        public async Task<ActionResult<Bus>> GetBusById(int id)
        {
            var bus = await _context.Buses.FindAsync(id);

            if (bus == null || bus.IsDeleted)
            {
                return NotFound();
            }

            return bus;
        }

        [HttpPost]
        [Route("InsertBus")]
        public async Task<ActionResult<Bus>> InsertBus(Bus bus)
        {
            bus.CreatedDate = DateTime.Now;
            bus.IsDeleted = false;

            _context.Buses.Add(bus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusById", new { id = bus.Id }, bus);
        }

        [HttpPut("UpdateBus/{id}")]
        public async Task<IActionResult> UpdateBus(int id, Bus bus)
        {
            if (id != bus.Id)
            {
                return BadRequest();
            }

            var existingBus = await _context.Buses.FindAsync(id);
            if (existingBus == null || existingBus.IsDeleted)
            {
                return NotFound();
            }

            existingBus.DoorNumber = bus.DoorNumber;
            existingBus.PlateNumber = bus.PlateNumber;
            existingBus.Photo = bus.Photo;

            _context.Entry(existingBus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusExists(id))
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

        [HttpDelete("DeleteBusById/{id}")]
        public async Task<IActionResult> DeleteBusById(int id)
        {
            var bus = await _context.Buses.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }

            bus.IsDeleted = true;
            _context.Buses.Update(bus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusExists(int id)
        {
            return _context.Buses.Any(e => e.Id == id && !e.IsDeleted);
        }
    }
}
