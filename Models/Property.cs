using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyCitizens.Models;

public class Property
{
    public int Id { get; set; }
    public int UserId { get; set; }

    [Required]
    public virtual User User { get; set; } = new User();

    [Required]
    public string MailingAddress { get; set; } = String.Empty;

    [Required]
    public string PhysicalAddress { get; set; } = String.Empty;

    public int YearBuilt { get; set; }

    [Required]
    public string DeputyAppraiser { get; set; } = String.Empty;
}