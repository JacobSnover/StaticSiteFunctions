using StaticSiteFunctions.DataTransferObjects.Interfaces;
using StaticSiteFunctions.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace StaticSiteFunctions.DataTransferObjects.BlogModels
{
    public class BlogCommentModel : CommonContact, IDtoMapper<BlogCommentModel, Commentor>
    {
        [Required]
        public int BlogId { get; set; }

        public static Commentor MapToDto(BlogCommentModel comment)
        {
            return new Commentor
            {
                BlogId = comment.BlogId,
                DatePosted = DateTime.Now.Date,
                Email = comment.Email,
                UserName = comment.Name ?? null,
                Liked = comment.Liked,
                Subscribe = comment.Subscribe,
                Body = comment.Body ?? string.Empty
            };
        }
    }
}
