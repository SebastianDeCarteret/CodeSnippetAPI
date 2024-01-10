using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeSnippetAPI.Models;

namespace CodeSnippetAPI.Data
{
    public class CodeSnippetAPIContext : DbContext
    {
        public CodeSnippetAPIContext (DbContextOptions<CodeSnippetAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CodeSnippetAPI.Models.User> User { get; set; } = default!;
    }
}
