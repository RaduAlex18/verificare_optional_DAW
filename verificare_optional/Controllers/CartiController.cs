using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using verificare_optional.Data;
using verificare_optional.Models;

namespace verificare_optional.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartiController : ControllerBase
    {
        private readonly tableContext _context;

        public CartiController(tableContext context)
        {
            _context = context;
        }

        // GET: api/Carti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carti>>> GetCarti()
        {
            return await _context.Cartis.ToListAsync();
        }

        // GET: api/Carti/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Carti>> GetCarti(Guid id)
        {
            var carti = await _context.Cartis.FindAsync(id);

            if (carti == null)
            {
                return NotFound();
            }

            return carti;
        }

        // POST: api/Carti
        [HttpPost]
        public async Task<ActionResult<Carti>> PostCarti(Carti carti)
        {
            _context.Cartis.Add(carti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarti", new { id = carti.Id }, carti);
        }
    }
}
