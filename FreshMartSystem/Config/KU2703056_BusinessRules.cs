using FreshMartSystem.Enums;

namespace FreshMartSystem.Config;

/// <summary>
/// Central place for all fixed business rules.
/// If a rule changes, only this file needs to be edited.
/// </summary>
public static class KU2703056_BusinessRules
{
    // An order total ABOVE this value earns the category discount (Assumption 4).
    public const decimal DiscountThreshold = 10000m;

    // Stock quantity at or below this value is "Low Stock" (Assumption 13).
    public const int LowStockLimit = 10;

    // Table 1: one rule per category, looked up by category (Dictionary).
    private static readonly Dictionary<KU2703056_ProductCategory, KU2703056_CategoryRule> categoryRules =
        new()
        {
            { KU2703056_ProductCategory.Vegetables,          new KU2703056_CategoryRule(300m, 2000m, 0.05m, 0.05m) },
            { KU2703056_ProductCategory.Fruits,              new KU2703056_CategoryRule(350m, 2500m, 0.05m, 0.05m) },
            { KU2703056_ProductCategory.Dairy,               new KU2703056_CategoryRule(400m, 3000m, 0.08m, 0.08m) },
            { KU2703056_ProductCategory.HouseholdEssentials, new KU2703056_CategoryRule(500m, 4000m, 0.10m, 0.10m) }
        };

    /// <summary>Returns the Table 1 rule for the given category.</summary>
    public static KU2703056_CategoryRule GetCategoryRule(KU2703056_ProductCategory category)
    {
        return categoryRules[category];
    }

    /// <summary>Returns a readable label for a delivery time slot.</summary>
    public static string GetTimeSlotLabel(KU2703056_TimeSlot slot)
    {
        return slot switch
        {
            KU2703056_TimeSlot.Morning => "Morning (09:00 - 12:00)",
            KU2703056_TimeSlot.Afternoon => "Afternoon (12:00 - 15:00)",
            KU2703056_TimeSlot.Evening => "Evening (15:00 - 18:00)",
            _ => "Unknown"
        };
    }
}
