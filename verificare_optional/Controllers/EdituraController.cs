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
    public class EdituraController : ControllerBase
    {
        private readonly tableContext _context;

        public EdituraController(tableContext context)
        {
            _context = context;
        }

        // GET: api/Editura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editura>>> GetEdituri()
        {
            return await _context.Edituras.Include(e => e.Autorii).ToListAsync();
        }

        // GET: api/Editura/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Editura>> GetEditura(Guid id)
        {
            var editura = await _context.Edituras.FindAsync(id);

            if (editura == null)
            {
                return NotFound();
            }

            return editura;
        }

        // POST: api/Editura
        [HttpPost]
        public async Task<ActionResult<Editura>> PostEditura(Editura editura)
        {
            _context.Edituras.Add(editura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEditura", new { id = editura.Id }, editura);
        }
    }
}
