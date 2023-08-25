using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectodawa.Data;
using proyectodawa.Models;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorteCabellosController : ControllerBase
    {
        private readonly ProyectoContext _context;

        public CorteCabellosController(ProyectoContext context)
        {
            _context = context;
        }

        // GET: api/CorteCabelloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorteCabello>>> GetCorteCabellos()
        {
          if (_context.CorteCabellos == null)
          {
              return NotFound();
          }
            return await _context.CorteCabellos.ToListAsync();
        }

        // GET: api/CorteCabelloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CorteCabello>> GetCorteCabello(int id)
        {
          if (_context.CorteCabellos == null)
          {
              return NotFound();
          }
            var corteCabello = await _context.CorteCabellos.FindAsync(id);

            if (corteCabello == null)
            {
                return NotFound();
            }

            return corteCabello;
        }

        // PUT: api/CorteCabelloes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorteCabello(int id, CorteCabello corteCabello)
        {
            if (id != corteCabello.IdCortecabello)
            {
                return BadRequest();
            }

            _context.Entry(corteCabello).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorteCabelloExists(id))
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

        // POST: api/CorteCabelloes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CorteCabello>> PostCorteCabello(CorteCabello corteCabello)
        {
          if (_context.CorteCabellos == null)
          {
              return Problem("Entity set 'ProyectoContext.CorteCabellos'  is null.");
          }
            _context.CorteCabellos.Add(corteCabello);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CorteCabelloExists(corteCabello.IdCortecabello))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCorteCabello", new { id = corteCabello.IdCortecabello }, corteCabello);
        }

        // DELETE: api/CorteCabelloes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCorteCabello(int id)
        {
            if (_context.CorteCabellos == null)
            {
                return NotFound();
            }
            var corteCabello = await _context.CorteCabellos.FindAsync(id);
            if (corteCabello == null)
            {
                return NotFound();
            }

            _context.CorteCabellos.Remove(corteCabello);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CorteCabelloExists(int id)
        {
            return (_context.CorteCabellos?.Any(e => e.IdCortecabello == id)).GetValueOrDefault();
        }
    }
}
