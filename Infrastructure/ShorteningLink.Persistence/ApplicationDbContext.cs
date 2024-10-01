using Microsoft.EntityFrameworkCore;
using ShorteningLink.Application.Interfaces;
using ShorteningLink.Domain;
using System.Diagnostics;

namespace ShorteningLink.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Link> Link { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);    
    }
}
