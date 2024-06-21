namespace Repositories.Dto
{

    public class ProductDto
    {
        public int ProductId { get; set; }

        public int ProductTypeId { get; set; }

        public string? ProductType { get; set; }

        public string ProductName { get; set; } = null!;

        public string? ProductDescription { get; set; }

        public bool? IsActive { get; set; }
    }
}
