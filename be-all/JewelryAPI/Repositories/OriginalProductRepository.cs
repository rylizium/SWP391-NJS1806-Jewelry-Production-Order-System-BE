using Repositories.Models;

namespace Repositories
{
    public class OriginalProductRepository
    {
        private JeweleryOrderProductionContext? _context;

        //ADD NEW PRODUCT & STOCK (ALREADY HAVE THINGS LIKE METALS, GEMSTONE,....)
        public void AddProduct(Product product) 
        {
            
            _context = new();
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void AddProductStock(ProductStock productStock)
        {
            _context = new();
            _context.ProductStocks.Add(productStock);
            _context.SaveChanges();
        }

        public void AddProductImage(ProductImage productImage)
        {
            _context= new();
            _context.ProductImages.Add(productImage);
            _context.SaveChanges();
            
        }

        



        
    }
}
