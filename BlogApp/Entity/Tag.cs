namespace BlogApp.Entity
{
    public class Tag
    {
        public enum TagColor
        {
            primary, success, warning, danger, secondary
        }
        public int TagId { get; set; }
        public string? TagText { get; set; }
        public string? Url { get; set; }
        public TagColor Color { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
