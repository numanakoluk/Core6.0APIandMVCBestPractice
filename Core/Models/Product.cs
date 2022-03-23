using Core.Model;

namespace Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        //public Product(string name)
        //{
        //    Name= name ?? throw new ArgumentNullException(nameof(Name));
        //}
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        //First Value dont be appointed.Because Nullable ProductFeature
        public ProductFeature? ProductFeature { get; set; }

    }
}
