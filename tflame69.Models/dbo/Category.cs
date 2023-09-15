using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tflame69.Models.dbo;

[Table("Category")]
public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    [Range(1,100)]
    public int DisplayOrder { get; set; }
}