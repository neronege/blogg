using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controls
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/users/login");
        }
    }
}
