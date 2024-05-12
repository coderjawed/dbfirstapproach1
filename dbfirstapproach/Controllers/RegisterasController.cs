using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dbfirstapproach.Models;

namespace dbfirstapproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterasController : ControllerBase
    {
        private readonly DbfirstapproachContext _context;

        public RegisterasController(DbfirstapproachContext context)
        {
            _context = context;
        }

        // GET: api/Registeras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registera>>> GetRegisteras()
        {
            return await _context.Registeras.ToListAsync();
        }

        // GET: api/Registeras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registera>> GetRegistera(int id)
        {
            var registera = await _context.Registeras.FindAsync(id);

            if (registera == null)
            {
                return NotFound();
            }

            return registera;
        }

        // PUT: api/Registeras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistera(int id, Registera registera)
        {
            if (id != registera.Id)
            {
                return BadRequest();
            }

            _context.Entry(registera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisteraExists(id))
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

        // POST: api/Registeras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Registera>> PostRegistera(Registera registera)
        {
            _context.Registeras.Add(registera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistera", new { id = registera.Id }, registera);
        }

        // DELETE: api/Registeras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistera(int id)
        {
            var registera = await _context.Registeras.FindAsync(id);
            if (registera == null)
            {
                return NotFound();
            }

            _context.Registeras.Remove(registera);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegisteraExists(int id)
        {
            return _context.Registeras.Any(e => e.Id == id);
        }
    }
}
