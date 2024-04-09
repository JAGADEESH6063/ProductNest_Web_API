using ProductNest.Models;

namespace ProductNest.Interfaces
{
    public interface IProductService
    {
        List<ProductModel> getAllProducts();
        List<ProductModel> AddMultipleProductstoNest(List<ProductModelOnAddandUpdate> products);
        ProductModel getOneProduct(Guid id);
        ProductModel? addProduct(ProductModelOnAddandUpdate productModel);
        string deleteProduct(Guid id);
        ProductModel updateProduct(Guid id, ProductModelOnAddandUpdate product);
    }
}
