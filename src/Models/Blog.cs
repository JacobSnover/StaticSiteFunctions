using System;
using System.Collections.Generic;

namespace StaticSiteFunctions.Models;

public partial class Blog
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Body { get; set; }

    public DateTime SubmitDate { get; set; }

    public DateTime? EditDate { get; set; }

    public string Topic { get; set; }

    public int? Likes { get; set; }

    public int? Views { get; set; }

    public bool? Published { get; set; }

    public virtual ICollection<Commentor> Commentors { get; set; } = new List<Commentor>();

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
