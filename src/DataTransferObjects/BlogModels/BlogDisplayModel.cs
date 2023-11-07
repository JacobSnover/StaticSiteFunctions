using StaticSiteFunctions.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StaticSiteFunctions.DataTransferObjects.BlogModels
{
    public class BlogDisplayModel
    {
        public BlogDisplayModel()
        {
            Tags = new List<Tag>();
            Photos = new List<Photo>();
            Commentors = new List<Commentor>();
        }
        public int BlogId { get; set; }
        public string Body { get; set; }
        public string Topic { get; set; }
        public string Title { get; set; }
        public int? Likes { get; set; }
        public int? Views { get; set; }
        public bool? Published { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Photo> Photos { get; set; }
        public List<Commentor> Commentors { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime? EditDate { get; set; }

        public static List<BlogDisplayModel> MapToList(Blog[] blogs)
        {
            var tempList = new List<BlogDisplayModel>();
            for (int i = 0; i < blogs.Length; i++)
            {
                tempList.Add(new BlogDisplayModel()
                {
                    BlogId = blogs[i].Id,
                    Body = blogs[i].Body,
                    Topic = blogs[i].Topic,
                    Title = blogs[i].Title,
                    Tags = blogs[i].Tags.ToList(),
                    Photos = blogs[i].Photos.ToList(),
                    Commentors = blogs[i].Commentors.ToList(),
                    SubmitDate = blogs[i].SubmitDate,
                    EditDate = blogs[i].EditDate,
                    Likes = blogs[i].Likes,
                    Views = blogs[i].Views,
                    Published = blogs[i].Published
                });
            }
            return tempList;
        }
    }
}