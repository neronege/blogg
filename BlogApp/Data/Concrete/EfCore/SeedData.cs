using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();
            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Entity.Tag { TagText = "web programlama", Url = "web-programlama", Color = Entity.Tag.TagColor.success },
                        new Entity.Tag { TagText = "backend", Url = "-backend", Color = Entity.Tag.TagColor.warning },
                        new Entity.Tag { TagText = "frontend", Url = "-frontend", Color = Entity.Tag.TagColor.danger },
                        new Entity.Tag { TagText = "fullstack", Url = "-fullstack", Color = Entity.Tag.TagColor.primary },
                        new Entity.Tag { TagText = "php", Url = "-php", Color = Entity.Tag.TagColor.warning }
                        );
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                      new Entity.User { UserName = "neronege", Email = "info@neronege.com", Password = "1234", Image = "p1.jpg", Name = "neron" },
                      new Entity.User { UserName = "neronegemen", Email = "info@neronegemen.com", Password = "1234", Image = "p2.jpg" },
                      new Entity.User { UserName = "neronmustafa", Email = "info@neronmustafa.com", Password = "1234", Image = "p3.jpg" }
                        );
                    context.SaveChanges();
                }
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Entity.Post
                        {
                            PostTitle = "Asp.net core",
                            PostContent = "Asp.net core dersleri",
                            PublishedOn = DateTime.Now.AddDays(-10),
                            IsActive = true,
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1,
                            Image = "3.jpg",
                            Url = "asp-net",
                            Comments = new List<Entity.Comment> {
                            new Entity.Comment
                            {
                                CommentText ="Ne muhteşem bir ders",
                                UserId = 1,
                                PublishedOn = new DateTime()
                            },
                            new Entity.Comment
                            {

                                CommentText ="Çok önemli bir kurs",
                                UserId = 2,
                                PublishedOn = DateTime.Now.AddDays(-2)
                            }
                                                                  }

                        },

                           new Entity.Post
                           {
                               PostTitle = "php",
                               PostContent = "php dersleri",
                               PublishedOn = DateTime.Now.AddDays(-30),
                               IsActive = true,
                               Tags = context.Tags.Take(2).ToList(),
                               UserId = 2,
                               Image = "1.jpg",
                               Url = "php",
                               Comments = new List<Entity.Comment>
                               {
                                   new Entity.Comment
                                   {
                                       UserId = 1,
                                       CommentText = "Etkili kurs",
                                       PublishedOn= DateTime.Now.AddDays(-10),
                                   },
                                   new Entity.Comment
                                   {
                                       UserId =3,
                                       CommentText = "Yararlı kurs",
                                       PublishedOn = DateTime.Now.AddDays(-15),
                                   }
                               }
                           },
                              new Entity.Post
                              {
                                  PostTitle = "Django",
                                  PostContent = "Django Dersleri",
                                  PublishedOn = DateTime.Now.AddDays(-20),
                                  IsActive = true,
                                  Tags = context.Tags.Take(4).ToList(),
                                  UserId = 3,
                                  Image = "2.jpg",
                                  Url = "django",
                                  Comments = new List<Entity.Comment>
                                  {
                                      new Entity.Comment
                                      {
                                       CommentText ="Django öğreinilmesi gereken bir kurs",
                                       UserId = 3,
                                       PublishedOn = DateTime.Now.AddDays(-5)
                                      },
                                      new Entity.Comment
                                      {
                                          CommentText =" Django client tarafında çalışan bir kurs",
                                          UserId = 1,
                                          PublishedOn = DateTime.Now.AddDays(-15)
                                      } ,
                                      new Entity.Comment
                                      {
                                          CommentText = "Django öğren hayatı kaçırma",
                                          UserId = 2,
                                          PublishedOn = new DateTime()
                                      }
                                  }

                              },
                                new Entity.Post
                                {
                                    PostTitle = "Javascrpit",
                                    PostContent = "Javascript Dersleri",
                                    PublishedOn = DateTime.Now.AddDays(-5),
                                    IsActive = true,
                                    Tags = context.Tags.Take(1).ToList(),
                                    UserId = 1,
                                    Image = "4.jpg",
                                    Url = "javascript",
                                    Comments = new List<Entity.Comment>
                                    {
                                        new Entity.Comment
                                        {
                                           UserId =2,
                                          CommentText = "Yoksa siz hala javascript öğrenmediniz mi?",
                                          PublishedOn = new DateTime()
                                        }
                                    }

                                }
                        );
                    context.SaveChanges();
                }
            }
        }
    }
}
