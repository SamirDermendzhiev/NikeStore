using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NikeStore.Entities;
using System.Reflection.Metadata;

namespace NikeStore.Models
{
    public class NikeContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ShoeTag> ShoeTags { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }

        public NikeContext(DbContextOptions<NikeContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItems>()
                .HasKey(p => new { p.Order_Id, p.Shoe_Id });
        }
    }
}