using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IPostRepository
    {    //IQueryable ile veritabanından filtreleme ile bilgileri çekebiliyoruz
        IQueryable<Post> Posts { get; }
        public void CreatePost(Post post);
    }
}
