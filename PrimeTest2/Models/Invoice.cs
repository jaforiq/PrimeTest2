namespace PrimeTest2.Models;

public class Invoice
{
    public int Id { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public int? Quentity { get; set; }
    public DateTime? PurchesDate { get; set; }
    public double? Total {  get; set; }
}
