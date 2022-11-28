using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace HappyCitizens.Models
{
    public class ApplicationUser : IdentityUser

    {
        override public string Id { get; set; } = String.Empty;

        [Required]
        public string FullName { get; set; } = String.Empty;

        [Required]
        public string Address { get; set; } = String.Empty;

        //[Required]
        //public string Email { get; set; } = String.Empty;

        public bool IsAdmin { get; set; }
        public virtual ICollection<Item> Inventory { get; set; } = new List<Item>();
        public virtual ICollection<ApplicationUser> SharedProfiles { get; set; } = new List<ApplicationUser>();
    }
}
