using System;
using System.Collections.Generic;

namespace StaticSiteFunctions.Models;

public partial class Photo
{
    public int Id { get; set; }

    public string Link { get; set; }

    public int BlogId { get; set; }

    public virtual Blog Blog { get; set; }
}
