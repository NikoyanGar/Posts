namespace Posts.Api.Models.ResponseModels
{
    public class PostCreationResponse
    {
        public PostCreationResponse(Guid id)
        {
            Id = id;
        }

        public PostCreationResponse(string title, Guid id, string content)
        {
            Title = title;
            Id = id;
            Content = content;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}