namespace FreshMartSystem.Models;

using FreshMartSystem.Enums;

/// <summary>
/// One line in an order. It copies the product's name, category and price
/// at the time of ordering (Assumption 16), so later product changes
/// or removals never alter an old invoice.
/// </summary>
public class KU2703056_OrderItem
{
    public string ProductId { get; }
    public string ProductName { get; }
    public KU2703056_ProductCategory Category { get; }
    public decimal UnitPrice { get; }
    public int Quantity { get; }

    /// <summary>Unit Price x Quantity (bill step 1 uses the sum of these).</summary>
    public decimal LineTotal => UnitPrice * Quantity;

    public KU2703056_OrderItem(KU2703056_Product product, int quantity)
    {
        ProductId = product.ProductId;
        ProductName = product.Name;
        Category = product.Category;
        UnitPrice = product.UnitPrice;
        Quantity = quantity;
    }
}
