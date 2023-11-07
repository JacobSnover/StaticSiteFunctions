using StaticSiteFunctions.Constants;
using StaticSiteFunctions.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StaticSiteFunctions.Infrastructure.SqlRepo
{
    public static class JsnoRepo
    {
        public static async Task<bool> SubmitBlog(Blog[] blogs)
        {
            try
            {
                using var db = new JsnoverdotnetdbContext();
                db.Blogs.Add(blogs[BlogIndexes.Blog]);
                await db.SaveChangesAsync();

                blogs[BlogIndexes.Photos].Photos.ToList().ForEach(photo => photo.BlogId = blogs[BlogIndexes.Blog].Id);
                await db.Photos.AddRangeAsync(blogs[BlogIndexes.Photos].Photos);
                await db.SaveChangesAsync();

                var blogTags = blogs[BlogIndexes.Tags].Tags.ToList();
                for (int i = 0; i < blogs[BlogIndexes.Tags].Tags.Count; i++)
                {
                    await db.Tags.AddAsync(new Tag
                    {
                        Id = 0,
                        BlogId = blogs[BlogIndexes.Blog].Id,
                        Name = blogTags[i].Name
                    });
                }
                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        internal static async Task<bool> UpdateBlog(Blog[] blogs)
        {
            try
            {
                using var db = new JsnoverdotnetdbContext();
                db.Blogs.Update(blogs[BlogIndexes.Blog]);
                await db.SaveChangesAsync();

                db.Photos.UpdateRange(blogs[BlogIndexes.Photos].Photos);
                await db.SaveChangesAsync();
                await db.Photos.AddRangeAsync(blogs[BlogIndexes.NewPhotos].Photos);
                await db.SaveChangesAsync();
                db.Photos.RemoveRange(blogs[BlogIndexes.RemovePhotos].Photos);
                await db.SaveChangesAsync();

                db.Tags.UpdateRange(blogs[BlogIndexes.Tags].Tags);
                await db.SaveChangesAsync();
                await db.Tags.AddRangeAsync(blogs[BlogIndexes.NewTags].Tags);
                await db.SaveChangesAsync();
                db.Tags.RemoveRange(blogs[BlogIndexes.RemoveTags].Tags);
                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal async static Task<bool> SubmitComment(Commentor commentors)
        {
            try
            {
                using var db = new JsnoverdotnetdbContext();
                var blog = db.Blogs.First(b => b.Id == commentors.BlogId);
                db.Commentors.Add(commentors);
                if (commentors.Liked)
                {
                    blog.Likes = blog.Likes is null ? 1 : (blog.Likes++);
                    db.Blogs.Update(blog);
                }
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        internal async static Task<bool> AddSubscriber(string email)
        {
            try
            {
                using var db = new JsnoverdotnetdbContext();

                if (db.Subscribers.Where(sub => sub.Email == email).Count() == 0)
                {
                    db.Subscribers.Add(new Subscriber()
                    {
                        Id = 0,
                        Email = email,
                        SubscribeDate = DateTime.Now
                    });
                    await db.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static async Task<bool> SubmitContactRequest(ContactRequest contactRequest)
        {
            try
            {
                using var db = new JsnoverdotnetdbContext();
                db.ContactRequests.Add(contactRequest);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
