namespace Backend.DTOs;

public class SaleUpdateDto 
{
    public int SaleId { get; set; }

     public int InventoryId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime SaleDate { get; set; }
    public string ClientName { get; set; } = null!;
}