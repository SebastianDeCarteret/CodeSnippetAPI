namespace CodeSnippetAPI.Models
{
    public class UserDto
    {
        public int? Id { get; init; }

        public List<SnippetDto> Snippets { get; set; } = [];
    }
}
