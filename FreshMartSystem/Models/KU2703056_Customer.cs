namespace FreshMartSystem.Models;

/// <summary>
/// Represents a registered FreshMart customer.
/// The NIC identifies the customer and never changes.
/// </summary>
public class KU2703056_Customer
{
    public string Nic { get; }                  // unique identifier, cannot be changed
    public string FullName { get; set; }
    public string ContactNumber { get; set; }
    public string DeliveryAddress { get; set; }
    public string Email { get; set; }

    public KU2703056_Customer(string nic, string fullName, string contactNumber,
                              string deliveryAddress, string email)
    {
        Nic = nic;
        FullName = fullName;
        ContactNumber = contactNumber;
        DeliveryAddress = deliveryAddress;
        Email = email;
    }
}
