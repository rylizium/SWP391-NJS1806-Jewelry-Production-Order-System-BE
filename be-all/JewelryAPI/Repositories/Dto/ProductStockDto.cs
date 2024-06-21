namespace SWP3.Dto
{
    public class ProductStockDto
    {
        public int ProductStockId { get; set; }

        public int ProductId { get; set; }

        public int GemstoneId { get; set; }

        public int MetalId { get; set; }

        public int? Size { get; set; }

        public int? StockQuantity { get; set; }

        public decimal Price { get; set; }

        public string? GalleryUrl { get; set; }
    }
}
