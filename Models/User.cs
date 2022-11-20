using System.ComponentModel.DataAnnotations;

namespace HappyCitizens.Models;
public class User
{
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; } = String.Empty;

    [Required]
    public string Address { get; set; } = String.Empty;

    [Required]
    public string Email { get; set; } = String.Empty;

    public bool IsAdmin { get; set; }
    public virtual ICollection<Item> Inventory { get; set; } = new List<Item>();
    public virtual ICollection<User> SharedProfiles { get; set; } = new List<User>();

    public User()
    {

    }

}
