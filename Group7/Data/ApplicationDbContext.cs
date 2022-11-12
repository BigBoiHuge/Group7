using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HappyCitizens.Models;

namespace HappyCitizens.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HappyCitizens.Models.User> User { get; set; } = default!;

        public DbSet<HappyCitizens.Models.Property>? Property { get; set; }
    }
}
