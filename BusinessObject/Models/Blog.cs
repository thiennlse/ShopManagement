using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Blog
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int MemberId { get; set; }

    public virtual Member Member { get; set; } = null!;
}
