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
    public class AutoriController : ControllerBase
    {
        private readonly tableContext _context;

        public AutoriController(tableContext context)
        {
            _context = context;
        }

        // GET: api/Autori
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autori>>> GetAutori()
        {
            return await _context.Autoris.ToListAsync();
        }

        // GET: api/Autori/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Autori>> GetAutori(Guid id)
        {
            var autori = await _context.Autoris.FindAsync(id);

            if (autori == null)
            {
                return NotFound();
            }

            return autori;
        }

        // POST: api/Autori
        [HttpPost]
        public async Task<ActionResult<Autori>> PostAutori(Autori autori)
        {
            _context.Autoris.Add(autori);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutori", new { id = autori.Id }, autori);
        }


        // GET: api/Autori/{id}/carti (endpoint care să primească un ID de autor și să returneze cartile asociate acelui autor)
        [HttpGet("{id}/carti")]
        public async Task<ActionResult<IEnumerable<Carti>>> GetCartiByAutor(Guid id)
        {
            var autor = await _context.Autoris.Include(a => a.ModelsRelationsAUCT)
                                             .ThenInclude(ra => ra.Carti)
                                             .FirstOrDefaultAsync(a => a.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            var carti = autor.ModelsRelationsAUCT.Select(ra => ra.Carti);

            return carti.ToList();
        }
    }
}
