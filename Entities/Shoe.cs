using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NikeStore.Entities
{
    public class Shoe
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Size { get; set; }
        public string Picture  { get; set; }
        public float Price { get; set; }
    }
}