using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface ITagRepository
    {    //IQueryable ile veritabanından filtreleme ile bilgileri çekebiliyoruz
        IQueryable<Tag> Tags { get; }
        public void CreateTag(Tag tag);
    }
}
