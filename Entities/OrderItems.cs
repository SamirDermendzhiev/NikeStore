using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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