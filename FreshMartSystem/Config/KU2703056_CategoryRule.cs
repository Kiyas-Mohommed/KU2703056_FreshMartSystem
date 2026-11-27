namespace FreshMartSystem.Config;

/// <summary>
/// Holds the Table 1 values for one product category.
/// Read-only: the values are set once and never change.
/// </summary>
public class KU2703056_CategoryRule
{
    public decimal DeliveryFee { get; }
    public decimal MinimumOrderValue { get; }
    public decimal DiscountRate { get; }   // e.g. 0.05 means 5%
    public decimal TaxRate { get; }        // e.g. 0.05 means 5%

    public KU2703056_CategoryRule(decimal deliveryFee, decimal minimumOrderValue,
                                  decimal discountRate, decimal taxRate)
    {
        DeliveryFee = deliveryFee;
        MinimumOrderValue = minimumOrderValue;
        DiscountRate = discountRate;
        TaxRate = taxRate;
    }
}
