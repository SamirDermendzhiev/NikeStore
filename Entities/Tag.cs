using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NikeStore.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public bool SetTag { get; set; }
    }
}