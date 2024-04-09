using ProductNest.Interfaces;
using ProductNest.Models;

namespace ProductNest.Service
    {
    public class ProductService : IProductService
        {
        private static List<ProductModel> Products = new List<ProductModel>();

        public ProductModel? addProduct(ProductModelOnAddandUpdate productModel)
            {
            if(string.IsNullOrWhiteSpace(productModel.Name) || string.IsNullOrWhiteSpace(productModel.Description)
                || productModel.Price <= 0)
                {
                return null;
                }
            ProductModel product = new ProductModel {
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
                Id = Guid.NewGuid()
                };
            Products.Add(product);
            return product;
            }

        public string deleteProduct(Guid id)
            {
            var product = Products.FirstOrDefault(x => x.Id == id);
            if (product == null) return null;
            Products.Remove(product);
            return "Product deleted successfully with ID: " + id;
        }

        public List<ProductModel> getAllProducts()
            {
            return Products;
            }

        public ProductModel getOneProduct(Guid id)
            {
            var product = Products.FirstOrDefault(x => x.Id == id);
            return product;
            }

        public ProductModel updateProduct(Guid id, ProductModelOnAddandUpdate product)
            {
            var existingProduct = Products.FirstOrDefault(y => y.Id == id);
            if (existingProduct == null) return null; 
            if(string.IsNullOrWhiteSpace(product.Name) || string.IsNullOrWhiteSpace(product.Description)
                || product.Price <= 0) { return null; }
            
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            return existingProduct;
            }
        public List<ProductModel> AddMultipleProductstoNest(List<ProductModelOnAddandUpdate> products)
            {
            var productsList = new List<ProductModel>();
            foreach (var productModel in products) 
                {
                    if(string.IsNullOrWhiteSpace(productModel.Name) || string.IsNullOrWhiteSpace(productModel.Description)
                    || productModel.Price <= 0)
                    {
                    return null;
                    }
                ProductModel product = new ProductModel {
                                        Name = productModel.Name,
                                        Description = productModel.Description,
                                        Price = productModel.Price,
                                        Id = Guid.NewGuid()
                                        };
                Products.Add(product);
                productsList.Add(product);
                }
            return productsList;
            }
        }
    }
