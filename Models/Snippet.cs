namespace CodeSnippetAPI.Models
{
    public class Snippet
    {
        public int Id { get; init; }

        public string Language { get; set; }

        public string Code { get; set; }

        //public int UserId { get; set; }
    }
}
