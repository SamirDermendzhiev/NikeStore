using Microsoft.EntityFrameworkCore;
using NikeStore.Entities;

namespace NikeStoreCore.Models
{
    public static class DatabaseSeed
    {
        public static void SeedDatabase(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedTags();
            modelBuilder.SeedShoes();
            modelBuilder.SeedShoeTags();
            modelBuilder.SeedUsers();
        }

        public static void SeedTags(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasData(
                new Tag() { Id = 1, Name = "Winter" },
                new Tag() { Id = 2, Name = "Summer" },
                new Tag() { Id = 3, Name = "Men" },
                new Tag() { Id = 4, Name = "Autumn" },
                new Tag() { Id = 5, Name = "Spring" },
                new Tag() { Id = 6, Name = "Women" },
                new Tag() { Id = 7, Name = "New" });
        }

        public static void SeedShoes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shoe>().HasData(
                new Shoe() { Id = 1, Name = "AirForce1Blue", Size = "41,42,43,44", Picture = "https://picsum.photos/200/300?random=1", Price = 199 },
                new Shoe() { Id = 2, Name = "AirJordan1RetroLow4", Size = "41,42,43,44", Picture = "https://picsum.photos/200/300?random=2", Price = 240 },
                new Shoe() { Id = 3, Name = "AirJordan2Wing", Size = "41,42,43,44", Picture = "https://picsum.photos/200/300?random=3", Price = 180 },
                new Shoe() { Id = 4, Name = "AirJordan4From", Size = "38", Picture = "https://picsum.photos/200/300?random=4", Price = 270 },
                new Shoe() { Id = 5, Name = "AirJOrdan4Knicks", Size = "41,42,43,44", Picture = "https://picsum.photos/200/300?random=5", Price = 140 },
                new Shoe() { Id = 6, Name = "AirJordan4Retro", Size = "38", Picture = "https://picsum.photos/200/300?random=6", Price = 230 },
                new Shoe() { Id = 7, Name = "AirJordan5", Size = "45,46,47", Picture = "https://picsum.photos/200/300?random=7", Price = 320 });
        }

        public static void SeedShoeTags(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoeTag>().HasData(
                new ShoeTag() { Id = 1, Shoe_Id = 1, Tag_Id = 1 },
                new ShoeTag() { Id = 2, Shoe_Id = 2, Tag_Id = 2 },
                new ShoeTag() { Id = 3, Shoe_Id = 3, Tag_Id = 3 },
                new ShoeTag() { Id = 4, Shoe_Id = 4, Tag_Id = 4 },
                new ShoeTag() { Id = 5, Shoe_Id = 5, Tag_Id = 5 },
                new ShoeTag() { Id = 6, Shoe_Id = 6, Tag_Id = 6 },
                new ShoeTag() { Id = 7, Shoe_Id = 7, Tag_Id = 7 });
        }

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Username = "nikiv", Password = "nikipass", Email = "nikiv@gmail.com", FirstName = "nikiv", LastName = "nikipass", Address = "nikihouse", PhoneNumber = "0896543210", IsAdmin = false },
                new User() { Id = 2, Username = "semo", Password = "memo", Email = "semo@abv.bg", FirstName = "semo", LastName = "memo", Address = "Memo", PhoneNumber = "0896543210", IsAdmin = true });
        }
    }
}
