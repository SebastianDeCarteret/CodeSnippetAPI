using CodeSnippetAPI.Data;
using CodeSnippetAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeSnippetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CodeSnippetAPIContext _context;

        public UsersController(CodeSnippetAPIContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            List<User> foundUsers = await _context.User.Include(user => user.Snippets).ToListAsync();
            List<UserDto> foundUsersDto = [];

            foreach (var user in foundUsers)
            {
                List<SnippetDto> snippetDtos = [];

                user.Snippets.ForEach(s =>
                {
                    var snippetDto = new SnippetDto()
                    {
                        Language = s.Language,
                        Code = s.Code
                    };
                    snippetDtos.Add(snippetDto);
                });
                var userDto = new UserDto()
                {
                    Id = user.Id,
                    Snippets = snippetDtos,
                };
                foundUsersDto.Add(userDto);
            }

            return Ok(foundUsersDto);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserSnippets(int id)
        {
            var foundUsers = await _context.User.Include(user => user.Snippets).ToListAsync();
            var user = foundUsers[id - 1];


            if (user == null)
            {
                return NotFound();
            }

            List<SnippetDto> snippetDtos = [];

            user.Snippets.ForEach(s =>
            {
                var snippetDto = new SnippetDto()
                {
                    Language = s.Language,
                    Code = s.Code
                };
                snippetDtos.Add(snippetDto);
            });

            var userDto = new UserDto()
            {
                Id = user.Id,
                Snippets = snippetDtos,
            };

            return userDto;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
