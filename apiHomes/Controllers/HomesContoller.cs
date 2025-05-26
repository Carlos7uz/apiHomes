using Microsoft.AspNetCore.Mvc;
using apiHomes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace apiHomes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HomesController(AppDbContext context)
        {
            _context = context;
        }


        // GET: api/homes
        [HttpGet]
        public async Task<ActionResult<List<Home>>> GetHomes()
        {
            var homes = await _context.Homes.ToListAsync();
            return Ok(homes); // ✅ retorna 200 com a lista
        }

        // GET: api/homes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Home>> GetHome(int id)
        {
            var home = await _context.Homes.FindAsync(id);

            if (home == null)
                return NotFound(); 

            return Ok(home); 
        }

        // POST: api/homes
        [HttpPost]
        public async Task<ActionResult<Home>> PostHome(Home home)
        {
            if (home == null) 
                return BadRequest(); 

            _context.Homes.Add(home);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHome), new { id = home.Id }, home); // ✅ usa GetHome como referência
        }

        // PUT: api/homes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHome(int id, Home home)
        {
            if (id != home.Id)
                return BadRequest();

            _context.Entry(home).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent(); 
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Homes.Any(h => h.Id == id))
                    return NotFound();

                throw;
            }
        }

        // DELETE: api/homes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHome(int id)
        {
            var home = await _context.Homes.FindAsync(id);

            if (home == null)
                return NotFound();

            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }
    }
}
