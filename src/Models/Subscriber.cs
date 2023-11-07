using System;
using System.Collections.Generic;

namespace StaticSiteFunctions.Models;

public partial class Subscriber
{
    public int Id { get; set; }

    public string Email { get; set; }

    public DateTime SubscribeDate { get; set; }
}
