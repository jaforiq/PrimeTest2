namespace PrimeTest2.Models;

public class ShoppingItemViewModel
{
    public List<ShoppingItem> Items { get; set; }
    public double? TotalPrice { get; set; }
    public int? TotalQuantity { get; set; }
}
