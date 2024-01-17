using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<BlogContext>(options =>
{

    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
});
//her interface çağrıldığında yapması için, 
//Interface'i ve implante edildiği somut class'ı yazıyoruz
builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
//Cookie özellüğünü uygulamaya tanıtıyrouz
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();


var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//SeedData'yı çağırıyoruz
SeedData.TestVerileriniDoldur(app);


app.MapControllerRoute(
    name: "post_details",
    pattern: "posts/details/{url}",
    defaults: new { controller = "Posts", action = "Details" }
    );
app.MapControllerRoute(
    name: "post_by_tag",
    pattern: "posts/tag/{url}",
    defaults: new { controller = "Posts", action = "Index" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
