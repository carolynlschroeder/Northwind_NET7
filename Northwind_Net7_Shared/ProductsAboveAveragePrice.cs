using System;
using System.Collections.Generic;

namespace Northwind_Net7_Shared;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
