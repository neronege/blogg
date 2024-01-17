using BlogApp.Data.Abstract;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogApp.Controls
{
    public class PostsController : Controller
    {
        IPostRepository _postrepository;
        ITagRepository _tagRepository;
        ICommentRepository _commentRepository;
        public PostsController(IPostRepository postrepository, ITagRepository tagRepository, ICommentRepository commentRepository)
        {
            _postrepository = postrepository;
            _tagRepository = tagRepository;
            _commentRepository = commentRepository;
        }
        public async Task<IActionResult> Index(string url)
        {
            var claims = User.Claims;
            var posts = _postrepository.Posts;
            if (!string.IsNullOrEmpty(url))
            {
                posts = posts.Where(x => x.Tags.Any(y => y.Url == url));
            }
            var model = new PostTagView
            {
                Posts = await posts.ToListAsync(),
                // Tags = _tagRepository.Tags.ToList()
            };
            return View(model);
        }
        public async Task<IActionResult> Details(string url)
        {
            return View(await _postrepository
                .Posts
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .ThenInclude(t => t.user)
                .FirstOrDefaultAsync(p => p.Url == url));
        }
        public IActionResult AddComment(int PostId, string CommentText, string url)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userImage = User.FindFirstValue(ClaimTypes.UserData);
            var model = new Comment
            {
                CommentText = CommentText,
                PostId = PostId,
                PublishedOn = DateTime.Now,
                UserId = Convert.ToInt32(userId),
                user = new User { UserName = userName, Image = userImage }

            };
            _commentRepository.CreateComment(model);


            return Redirect("/posts/details/" + url);

        }
    }
}
