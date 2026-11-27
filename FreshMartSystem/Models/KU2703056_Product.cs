using FreshMartSystem.Config;
using FreshMartSystem.Enums;

namespace FreshMartSystem.Models;

/// <summary>
/// Represents one product in the FreshMart inventory.
/// Encapsulation: stock can only be changed through the methods below.
/// </summary>
public class KU2703056_Product
{
    public string ProductId { get; }                       // unique, never changes
    public string Name { get; set; }
    public KU2703056_ProductCategory Category { get; set; }
    public decimal UnitPrice { get; set; }
    public int StockQuantity { get; private set; }         // only this class can change it

    /// <summary>
    /// Stock status is derived from the quantity (Assumption 13),
    /// so it can never be out of sync with the stock.
    /// </summary>
    public KU2703056_StockStatus StockStatus
    {
        get
        {
            if (StockQuantity == 0)
                return KU2703056_StockStatus.OutOfStock;
            if (StockQuantity <= KU2703056_BusinessRules.LowStockLimit)
                return KU2703056_StockStatus.LowStock;
            return KU2703056_StockStatus.InStock;
        }
    }

    public KU2703056_Product(string productId, string name,
                             KU2703056_ProductCategory category,
                             decimal unitPrice, int stockQuantity)
    {
        ProductId = productId;
        Name = name;
        Category = category;
        UnitPrice = unitPrice;
        StockQuantity = stockQuantity;
    }

    /// <summary>Admin sets a new stock quantity.</summary>
    public void SetStockQuantity(int newQuantity)
    {
        if (newQuantity < 0)
            throw new ArgumentException("Stock quantity cannot be negative.");
        StockQuantity = newQuantity;
    }

    /// <summary>Reduces stock when an order is placed.</summary>
    public void ReduceStock(int quantity)
    {
        if (quantity <= 0 || quantity > StockQuantity)
            throw new ArgumentException("Invalid quantity for the available stock.");
        StockQuantity -= quantity;
    }

    /// <summary>Restores stock when an order is cancelled.</summary>
    public void RestoreStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");
        StockQuantity += quantity;
    }
}
