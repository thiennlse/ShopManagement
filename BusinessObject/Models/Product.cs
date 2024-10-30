﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Quantity { get; set; }

    public double Price { get; set; }

    public int? MemberId { get; set; }

    public virtual Member? Member { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
