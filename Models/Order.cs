using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceTracker.Models;

public class Order
{
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(256)]
    public string CustomerEmail { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
