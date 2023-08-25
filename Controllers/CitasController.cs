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
    public class CitasController : ControllerBase
    {
        private readonly ProyectoContext _context;

        public CitasController(ProyectoContext context)
        {
            _context = context;
        }

        // GET: api/Citas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Citum>>> GetCita()
        {
          if (_context.Cita == null)
          {
              return NotFound();
          }
            return await _context.Cita.ToListAsync();
        }

        // GET: api/Citas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Citum>> GetCitum(int id)
        {
          if (_context.Cita == null)
          {
              return NotFound();
          }
            var citum = await _context.Cita.FindAsync(id);

            if (citum == null)
            {
                return NotFound();
            }

            return citum;
        }

        // PUT: api/Citas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitum(int id, Citum citum)
        {
            if (id != citum.IdCita)
            {
                return BadRequest();
            }

            _context.Entry(citum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitumExists(id))
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

        // POST: api/Citas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Citum>> PostCitum(Citum citum)
        {
          if (_context.Cita == null)
          {
              return Problem("Entity set 'ProyectoContext.Cita'  is null.");
          }
            _context.Cita.Add(citum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CitumExists(citum.IdCita))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCitum", new { id = citum.IdCita }, citum);
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCitum(int id)
        {
            if (_context.Cita == null)
            {
                return NotFound();
            }
            var citum = await _context.Cita.FindAsync(id);
            if (citum == null)
            {
                return NotFound();
            }

            _context.Cita.Remove(citum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CitumExists(int id)
        {
            return (_context.Cita?.Any(e => e.IdCita == id)).GetValueOrDefault();
        }
    }
}
