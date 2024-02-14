using System.ComponentModel.DataAnnotations.Schema;

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