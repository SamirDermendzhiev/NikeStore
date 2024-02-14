using NikeStore.Entities;

namespace NikeStore.ViewModels.Home
{
    public class IndexVM
    {
        public List<Shoe> Shoes { get; set; }
        public List<Tag> Tags { get; set; }
        public List<ShoeTag> Shoetags { get; set; }
        public int Page { get; set; }
        public int PageCount { get; set; }
        public int ItemsPerPage { get; set; }
        public Tag search { get; set; }
    }
}