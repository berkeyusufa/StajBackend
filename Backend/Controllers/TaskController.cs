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
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TaskController/GetAllTasks
        [HttpGet]
        [Route("GetAllTasks")]
        public async Task<ActionResult<IEnumerable<BusManagement.Models.Task>>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/TaskController/GetTaskById/{id}
        [HttpGet("GetTaskById/{id}")]
        public async Task<ActionResult<BusManagement.Models.Task>> GetTaskById(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // GET: api/TaskController/GetDriverByTaskId/{taskId}
        [HttpGet("GetDriverByTaskId/{taskId}")]
        public async Task<ActionResult<Driver>> GetDriverByTaskId(int taskId)
        {
            var task = await _context.Tasks.Include(t => t.Driver).FirstOrDefaultAsync(t => t.Id == taskId);

            if (task == null || task.Driver == null)
            {
                return NotFound();
            }

            return Ok(task.Driver);
        }

        // GET: api/TaskController/GetBusByTaskId/{taskId}
        [HttpGet("GetBusByTaskId/{taskId}")]
        public async Task<ActionResult<Bus>> GetBusByTaskId(int taskId)
        {
            var task = await _context.Tasks.Include(t => t.Bus).FirstOrDefaultAsync(t => t.Id == taskId);

            if (task == null || task.Bus == null)
            {
                return NotFound();
            }

            return Ok(task.Bus);
        }

        // POST: api/TaskController/AssignTask
        [HttpPost]
        [Route("AssignTask")]
        public async Task<ActionResult<BusManagement.Models.Task>> AssignTask(BusManagement.Models.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskById", new { id = task.Id }, task);
        }

        // PUT: api/TaskController/UpdateTask/{id}
        [HttpPut("UpdateTask/{id}")]
        public async Task<IActionResult> UpdateTask(int id, BusManagement.Models.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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

        // DELETE: api/TaskController/DeleteTaskById/{id}
        [HttpDelete("DeleteTaskById/{id}")]
        public async Task<IActionResult> DeleteTaskById(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
