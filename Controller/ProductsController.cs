using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPITest.Domains;
using ProjectAPITest.Interface;
using ProjectAPITest.Repositories;

namespace ProjectAPITest.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private IProductsRepository _products {  get; set; }

        public ProductsController()
        {
            _products = new ProductsRepositories();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(200, _products.Get());
            }
            catch (Exception)
            {
                return BadRequest("Falha a o exibir os dados.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetId(Guid id)
        {
            try
            {
                return StatusCode(200, _products.GetById(id));
            }
            catch (Exception)
            {
                return BadRequest($"Falha ao exibir dados do produto {id}");
            }
        }

        [HttpPost]
        public IActionResult Post(Products newProduct)
        {
            try
            {
                _products.Post(newProduct);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest("Falha ao criar novo produto.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Products productAlterate)
        {
            try
            {
                _products.Put(id, productAlterate);
                return NoContent() ;
            }
            catch (Exception)
            {
                return BadRequest($"Falha ao alterar os dados com id {id}.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _products.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest("Falha a o exibir os dados.");
            }
        }

    }
}
