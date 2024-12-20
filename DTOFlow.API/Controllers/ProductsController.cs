using DTOFlow.API.Data;
using DTOFlow.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DTOFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DTOFlowDbContext dbContext;

        public ProductsController(DTOFlowDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Get all products
        [HttpGet]
        public IActionResult GetAll()
        {
            //Get data from database (Domain model)
            var productsDomain = dbContext.Products.ToList();

            //Map Domain Models to DTOs
            var productsDto = new List<ProductDto>();
            foreach (var productDomain in productsDomain)
            {
                productsDto.Add(new ProductDto()
                {
                    Id = productDomain.Id,
                    Name = productDomain.Name,
                    Description = productDomain.Description,
                    Price = productDomain.Price,
                    StockQuantity = productDomain.StockQuantity
                });
            }

            //Return DTOs to the client
            return Ok(productsDto);
        }

        //Get a single product
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //Get data from database (Domain model)
            var productDomain = dbContext.Products.FirstOrDefault(x => x.Id == id);

            if (productDomain == null)
            {
                return NotFound();
            }

            //Map Domain Models to DTOs
            var productDto = new ProductDto
            {
                Id = productDomain.Id,
                Name = productDomain.Name,
                Description = productDomain.Description,
                Price = productDomain.Price,
                StockQuantity = productDomain.StockQuantity
            };

            //Return DTO to the client
            return Ok(productDto);
        }
    }
}
