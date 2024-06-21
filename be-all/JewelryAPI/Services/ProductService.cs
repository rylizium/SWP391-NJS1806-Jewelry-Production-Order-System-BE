using Repositories;
using Repositories.Models;
using Repositories.QueryObjects;
using Repositories.Dto;

namespace Services
{
    public class ProductService
    {
        ProductRepository _ProductRepo = new ProductRepository();
        OriginalProductTypeRepository _originalProductTypeRepo = new OriginalProductTypeRepository();
        public List<ProductDto> GetAllProduct(ProductQueryObject productQuery)
        {
            return _ProductRepo.GetAllProducts(productQuery);
        }

        public List<ProductDto> GetAllActiveProduct()
        {
            return _ProductRepo.GetAllActiveProducts();
        }

        public ProductDto? GetProductById(int id)
        {
            return _ProductRepo.GetProductById(id);
        }
        //CREATE
        public void CreateProduct(Product product)
        { 
            _ProductRepo.CreateProduct(product);
        }

        //UPDATE
        public void UpdateProduct(Product product) 
        {
            _ProductRepo.UpdateProduct(product);
        }


        //GET ALL PRODUCT TYPE
        public List<ProductType> GetAllProductTypes()
        {
            return _originalProductTypeRepo.GetAllProductTypes();
        }
    }
}
