using apiHomes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/review
        [HttpGet]
        public async Task<ActionResult<List<Review>>> GetReview()
        {
            var Review = await _context.Review.ToListAsync();
            return Ok(Review); // ✅ retorna 200 com a lista
        }

        // GET: api/Review/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Review.FindAsync(id);

            if (review == null)
                return NotFound();

            return Ok(review);
        }

        // POST: api/Review
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            if (review == null)
                return BadRequest();

            _context.Review.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review); // ✅ usa GetReview como referência
        }

        // PUT: api/Review/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id != review.Id)
                return BadRequest();

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Review.Any(h => h.Id == id))
                    return NotFound();

                throw;
            }
        }

        // DELETE: api/Review/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var Review = await _context.Review.FindAsync(id);

            if (Review == null)
                return NotFound();

            _context.Review.Remove(Review);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
