using Microsoft.EntityFrameworkCore;

namespace CodeSnippetAPI.Data
{
    public class CodeSnippetAPIContext : DbContext
    {
        public CodeSnippetAPIContext(DbContextOptions<CodeSnippetAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CodeSnippetAPI.Models.User> User { get; set; } = default!;
        public DbSet<CodeSnippetAPI.Models.Snippet> Snippet { get; set; } = default!;
    }
}
