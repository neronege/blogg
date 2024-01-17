﻿namespace BlogApp.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? CommentText { get; set; }
        public DateTime PublishedOn { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; } = null!;

        public int UserId { get; set; }
        public User user { get; set; } = null!;
    }
}
