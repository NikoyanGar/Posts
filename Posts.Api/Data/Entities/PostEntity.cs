namespace Posts.Api.Data.Entities
{
    public class PostEntity
    {
        public int UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
