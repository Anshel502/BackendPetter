using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Sale
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SaleId { get; set; }
    public int InventoryId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime SaleDate { get; set; }
    public string ClientName { get; set; } = null!;

    [ForeignKey("InventoryId")]
    public virtual Inventory Inventory { get; set; } = null!;
}