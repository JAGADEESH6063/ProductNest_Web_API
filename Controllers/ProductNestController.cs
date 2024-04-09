using Microsoft.AspNetCore.Mvc;
using ProductNest.Interfaces;
using ProductNest.Models;

namespace ProductNest.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductNestController : ControllerBase
        {
        private readonly IProductService _productService;

        public ProductNestController(IProductService productService)
            {
            _productService = productService;
            }

        // GET: api/ProductNestController/GetAll
        [HttpGet("GetAllProductsFromNest")]
        public ActionResult<List<ProductModel>> GetAllProductsFromNest()
            {
            var products = _productService.getAllProducts();
            if(products == null || products.Count == 0)
                {
                return Ok("Nest is Empty.....");
                }
            return Ok(products);
            }

        // GET api/<ProductNestController>/5
        [HttpGet("GetOneProductfromNest/{id}")]
        public ActionResult<ProductModel> GetOneProductfromNest(Guid id)
            {
            var product = _productService.getOneProduct(id);
            if(product == null) 
                {
                return BadRequest(new { Message = "Product not found in the Nest" });
                }
            return product;
            }

        // POST api/<ProductNestController>
        [HttpPost("AddProducttoNest")]
        public ActionResult<ProductModel> AddProducttoNest([FromBody] ProductModelOnAddandUpdate
            product)
            {
            var result = _productService.addProduct(product);
            if(result == null) 
                {
                return BadRequest(new {Message = "Invalid Product Data"});
                }
            return Ok(result);
            }
        [HttpPost("AddMultipleProductstoNest")]
        public ActionResult<ProductModel> AddMultipleProductstoNest([FromBody] 
        List<ProductModelOnAddandUpdate> products)
            {
            var result = _productService.AddMultipleProductstoNest(products);
            if(result == null) 
                {
                return BadRequest(new { Message = "Invalid Product Data" });
                }
            return Ok(result);
            }
        // PUT api/<ProductNestController>/5
        [HttpPut("UpdateProductonNest/{id}")]
        public ActionResult<ProductModel> UpdateProductonNest(Guid id, 
            [FromBody] ProductModelOnAddandUpdate product)
            {
            var updatedProduct = _productService.updateProduct(id, product);
            if(updatedProduct == null)
                {
                return BadRequest(new { Message = "Product ID or Data is Invalid!!!!!" });
                }
            return Ok(updatedProduct);
            }

        // DELETE api/<ProductNestController>/5
        [HttpDelete("DeleteProductFromNest/{id}")]
        public ActionResult<string> DeleteProductFromNest(Guid id)
            {
            var result = _productService.deleteProduct(id);
            if (result == null) return BadRequest(new { Message = "Product Not Found with ID: " + id });
            return result;
            }
        }
    }
