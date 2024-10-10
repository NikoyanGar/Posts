namespace Posts.Api.Models.RequestModels
{
    public class PostCrerationRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}