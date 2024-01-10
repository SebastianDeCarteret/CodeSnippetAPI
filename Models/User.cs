namespace CodeSnippetAPI.Models
{
    public class User
    {
        public int Id { get; init; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Snippet> Snippets { get; set; } = [];
    }
}
