using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Order
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int Quantity { get; set; }

    public double? TotalPrice { get; set; }

    public int? MemberId { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
