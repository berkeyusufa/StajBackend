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
    public class DriversController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DriversController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Drivers
        [HttpGet]
        [Route("GetAllDrivers")]
        public async Task<ActionResult<IEnumerable<Driver>>> GetAllDrivers()
        {
            var drivers = await _context.Drivers.Where(a => !a.IsDeleted).ToListAsync();

            foreach (var driver in drivers.Where(d => d.CreatedDate == DateTime.MinValue))
            {
                driver.CreatedDate = DateTime.Today;
                _context.Drivers.Update(driver);
            }
            await _context.SaveChangesAsync();

            return drivers.OrderByDescending(d => d.CreatedDate).ToList();
        }


        // GET: api/Drivers/5
        [HttpGet("GetDriverById/{id}")]
        public async Task<ActionResult<Driver>> GetDriverById(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);

            if (driver == null || driver.IsDeleted)
            {
                return NotFound();
            }

            return driver;
        }

        // POST: api/Drivers
        [HttpPost]
        [Route("InsertDriver")]
        public async Task<ActionResult<Driver>> InsertDriver(Driver driver)
        {
            

            driver.CreatedDate = DateTime.Now;
            driver.IsDeleted = false;
            driver.IsAvailable = false;

            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriverById", new { id = driver.Id }, driver);
        }


        // PUT: api/Drivers/5
        [HttpPut("UpdateDriver/{id}")]
        public async Task<IActionResult> UpdateDriver(int id, Driver driver)
        {
            if (id != driver.Id)
            {
                return BadRequest();
            }

            var existingDriver = await _context.Drivers.FindAsync(id);
            if (existingDriver == null || existingDriver.IsDeleted)
            {
                return NotFound();
            }

            existingDriver.Name = driver.Name;
            existingDriver.Surname = driver.Surname;
            existingDriver.Age = driver.Age;

            _context.Entry(existingDriver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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

        // DELETE: api/Drivers/5
        [HttpDelete("DeleteDriverById/{id}")]
        public async Task<IActionResult> DeleteDriverById(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }
            driver.IsDeleted = true;
            driver.IsAvailable = true;
            _context.Drivers.Update(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.Id == id && !e.IsDeleted);
        }
    }
}
