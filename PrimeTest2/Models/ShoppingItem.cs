namespace PrimeTest2.Models;

public class ShoppingItem
{
    public Guid Id { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}
