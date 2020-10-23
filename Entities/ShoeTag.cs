 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NikeStore.Entities
{
    public class ShoeTag
    {
        public int Id { get; set; }
        public int Shoe_Id { get; set; }
        public int Tag_Id { get; set; }
    }
}