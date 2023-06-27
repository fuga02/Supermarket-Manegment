using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBusiness;
[Table("products_1")]
public class Product
{
    public int ProductId { get; set; }
    [Required]
    public int? CategoryId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int? Quantity { get; set; }
    [Required]
    public double? Price { get; set; }

    public Category Category { get; set; }
}