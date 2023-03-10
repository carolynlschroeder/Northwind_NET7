using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Northwind_Net7_Shared;

public partial class Product
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product Name is required")]
    public string ProductName { get; set; } = null!;

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    public string? QuantityPerUnit { get; set; }

    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual Supplier? Supplier { get; set; }
}
