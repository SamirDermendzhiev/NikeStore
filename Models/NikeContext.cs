using NikeStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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

        public NikeContext()
            : base("Server=localhost;database=NikeDB;Trusted_Connection=true")
        {
            Users = this.Set<User>();
            Shoes = this.Set<Shoe>();
            Tags = this.Set<Tag>();
            ShoeTags = this.Set<ShoeTag>();
            Orders = this.Set<Order>();
            OrderItems = this.Set<OrderItems>();
        }
    }
}