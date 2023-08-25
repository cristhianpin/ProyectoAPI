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
    public class CortesController : ControllerBase
    {
        private readonly ProyectoContext _context;

        public CortesController(ProyectoContext context)
        {
            _context = context;
        }

        // GET: api/Cortes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Corte>>> GetCortes()
        {
          if (_context.Cortes == null)
          {
              return NotFound();
          }
            return await _context.Cortes.ToListAsync();
        }

        // GET: api/Cortes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Corte>> GetCorte(int id)
        {
          if (_context.Cortes == null)
          {
              return NotFound();
          }
            var corte = await _context.Cortes.FindAsync(id);

            if (corte == null)
            {
                return NotFound();
            }

            return corte;
        }

        // PUT: api/Cortes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorte(int id, Corte corte)
        {
            if (id != corte.IdCortes)
            {
                return BadRequest();
            }

            _context.Entry(corte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorteExists(id))
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

        // POST: api/Cortes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Corte>> PostCorte(Corte corte)
        {
          if (_context.Cortes == null)
          {
              return Problem("Entity set 'ProyectoContext.Cortes'  is null.");
          }
            _context.Cortes.Add(corte);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CorteExists(corte.IdCortes))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCorte", new { id = corte.IdCortes }, corte);
        }

        // DELETE: api/Cortes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCorte(int id)
        {
            if (_context.Cortes == null)
            {
                return NotFound();
            }
            var corte = await _context.Cortes.FindAsync(id);
            if (corte == null)
            {
                return NotFound();
            }

            _context.Cortes.Remove(corte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CorteExists(int id)
        {
            return (_context.Cortes?.Any(e => e.IdCortes == id)).GetValueOrDefault();
        }
    }
}
