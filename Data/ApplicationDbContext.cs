using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HappyCitizens.Models;

namespace HappyCitizens.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<HappyCitizens.Models.Item> Item { get; set; } = default!;
        public DbSet<HappyCitizens.Models.ApplicationUser> User { get; set; } = default!;
    }
}