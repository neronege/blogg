using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class NewPosts : ViewComponent
    {
        private IPostRepository _postRepository;
        public NewPosts(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await
                       _postRepository
                       .Posts
                       .OrderByDescending(p => p.PublishedOn)
                       .Take(5)
                       .ToListAsync();
            return View(result);
        }

    }
}
