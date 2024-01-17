namespace BlogApp.Entity
{
    public class Post
    {
        public int PostId { get; set; }
        public string? PostTitle { get; set; }
        public string? PostContent { get; set; }
        public string? Image { get; set; }
        public string? Url { get; set; }
        public DateTime PublishedOn { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public User user { get; set; } = new User();
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Comment> Comments { get; set; } = new List<Comment>();


    }
}
