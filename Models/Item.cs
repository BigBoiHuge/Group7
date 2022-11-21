using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyCitizens.Models;

public enum Condition
{
    New,
    Excellent,
    Good,
    Average,
    Poor
}

public enum Category
{
    Electronics,
    Furniture,
    Artwork,
    Clothing,
    Jewelry,
    Misc
}

public class Item
{
    public int Id { get; set; }

    [Display(Name = "Owner")]
    public int UserId { get; set; }

    [Required]
    public virtual User User { get; set; } = new User();

    [Required]
    public string Room { get; set; } = String.Empty;

    [Required]
    public string Description { get; set; } = String.Empty;

    public Category Category { get; set; }

    [DataType(DataType.Date), Display(Name = "Purchase Date")]
    public DateTime PurchaseDate { get; set; }

    public Condition Condition { get; set; }

    [DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Display(Name = "Insured?")]
    public bool IsInsured { get; set; }
}