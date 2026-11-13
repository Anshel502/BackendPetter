using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Supplier
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SupplierId { get; set; }
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Phone { get; set; } = null!;

    public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();
}