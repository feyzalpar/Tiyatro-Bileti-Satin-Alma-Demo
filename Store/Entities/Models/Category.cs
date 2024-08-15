namespace Entities.Models
{
    public class Category
    {
        //nesne ilişkisi
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; } = String.Empty;

        //collection navigation nesne arası dolasma
        public ICollection<Product> Products { get; set; }
    }
}
