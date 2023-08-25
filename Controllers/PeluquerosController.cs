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
    public class PeluquerosController : ControllerBase
    {
        private readonly ProyectoContext _context;

        public PeluquerosController(ProyectoContext context)
        {
            _context = context;
        }

        // GET: api/Peluqueroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peluquero>>> GetPeluqueros()
        {
          if (_context.Peluqueros == null)
          {
              return NotFound();
          }
            return await _context.Peluqueros.ToListAsync();
        }

        // GET: api/Peluqueroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Peluquero>> GetPeluquero(int id)
        {
          if (_context.Peluqueros == null)
          {
              return NotFound();
          }
            var peluquero = await _context.Peluqueros.FindAsync(id);

            if (peluquero == null)
            {
                return NotFound();
            }

            return peluquero;
        }

        // PUT: api/Peluqueroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeluquero(int id, Peluquero peluquero)
        {
            if (id != peluquero.IdPeluquero)
            {
                return BadRequest();
            }

            _context.Entry(peluquero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeluqueroExists(id))
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

        // POST: api/Peluqueroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Peluquero>> PostPeluquero(Peluquero peluquero)
        {
          if (_context.Peluqueros == null)
          {
              return Problem("Entity set 'ProyectoContext.Peluqueros'  is null.");
          }
            _context.Peluqueros.Add(peluquero);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PeluqueroExists(peluquero.IdPeluquero))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPeluquero", new { id = peluquero.IdPeluquero }, peluquero);
        }

        // DELETE: api/Peluqueroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeluquero(int id)
        {
            if (_context.Peluqueros == null)
            {
                return NotFound();
            }
            var peluquero = await _context.Peluqueros.FindAsync(id);
            if (peluquero == null)
            {
                return NotFound();
            }

            _context.Peluqueros.Remove(peluquero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeluqueroExists(int id)
        {
            return (_context.Peluqueros?.Any(e => e.IdPeluquero == id)).GetValueOrDefault();
        }
    }
}
