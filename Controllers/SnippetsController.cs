using CodeSnippetAPI.Data;
using CodeSnippetAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeSnippetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnippetsController : ControllerBase
    {
        private readonly CodeSnippetAPIContext _context;

        public SnippetsController(CodeSnippetAPIContext context)
        {
            _context = context;
        }

        // GET: api/Snippets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Snippet>>> GetSnippets()
        {
            return await _context.Snippet.ToListAsync();
        }

        // GET: api/Snippets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Snippet>> GetSnippet(int? id)
        {
            var snippet = await _context.Snippet.FindAsync(id);

            if (snippet == null)
            {
                return NotFound();
            }

            return snippet;
        }

        // PUT: api/Snippets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSnippet(int? id, Snippet snippet)
        {
            if (id != snippet.Id)
            {
                return BadRequest();
            }

            _context.Entry(snippet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SnippetExists(id))
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

        // POST: api/Snippets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Snippet>> PostSnippet(Snippet snippet)
        {
            _context.Snippet.Add(snippet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSnippet", new { id = snippet.Id }, snippet);
        }

        // DELETE: api/Snippets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSnippet(int? id)
        {
            var snippet = await _context.Snippet.FindAsync(id);
            if (snippet == null)
            {
                return NotFound();
            }

            _context.Snippet.Remove(snippet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SnippetExists(int? id)
        {
            return _context.Snippet.Any(e => e.Id == id);
        }
    }
}
