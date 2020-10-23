using NikeStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikeStore.ViewModels.Home
{
    public class CartVM
    {
        public List<Shoe> Items { get; set; }
    }
}