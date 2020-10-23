using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikeStore.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public float Price { get; set; }
        public string Client { get; set; }
        public string Addres { get; set; }
        public DateTime Date { get; set; }

    }
}