using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IUserRepository
    {    //IQueryable ile veritabanından filtreleme ile bilgileri çekebiliyoruz
        IQueryable<User> Users { get; }
        public void CreateUser(User user);
    }
}
