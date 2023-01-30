using System;
using System.Collections.Generic;

namespace Northwind_Net7_Shared;

public partial class CategoryExt
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public string Base64String { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
