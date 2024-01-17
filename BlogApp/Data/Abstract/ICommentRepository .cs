using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface ICommentRepository
    {    //IQueryable ile veritabanından filtreleme ile bilgileri çekebiliyoruz
        IQueryable<Comment> Comments { get; }
        public void CreateComment(Comment comment);
    }
}
