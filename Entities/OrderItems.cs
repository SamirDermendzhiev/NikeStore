using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NikeStore.Entities
{
    public class OrderItems
    {
        [Key]
        [Column(Order = 1)]
        public int Order_Id { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Shoe_Id { get; set; }
    }
}