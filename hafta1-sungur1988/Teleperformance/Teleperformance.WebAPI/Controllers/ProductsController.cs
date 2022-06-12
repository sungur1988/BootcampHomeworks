using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Teleperformance.WebAPI.Models;
using System;
using System.Linq;
using Mapster;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.JsonPatch;

namespace Teleperformance.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private List<Product> _productList= new()
        {
            new Product { Id = 1, Name = "Kalem", Price = 5, CategoryId = 1, CreatedAt = DateTime.Today.AddDays(-1) }
                                   ,
            new Product { Id = 2, Name = "Defter", Price = 10, CategoryId = 2, CreatedAt = DateTime.Today }
        };
        private readonly LinkGenerator _linkGenerator;

        public ProductsController(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }
        [HttpGet]
        public IActionResult GetList([FromQuery]bool order =false)
        {
            var productList = order ?  _productList.OrderBy(x=>x.Name).ToList() : _productList;
            var result = productList.Adapt<IEnumerable<ProductUserDto>>();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var product = _productList.FirstOrDefault(x=>x.Id==id);
            if (product == null)
            {
                return NotFound();
            }
            var result = product.Adapt<ProductUserDto>();
            return Ok(result);

        }
        [HttpPost]
        public IActionResult AddProduct([FromBody]ProductAddDto product)
        {
            var productToAdd = product.Adapt<Product>();
            productToAdd.CreatedAt = DateTime.Now;
            _productList.Add(productToAdd);
            var url = _linkGenerator.GetPathByAction("GetById", "Products", new { id = product.Id });
            return Created(url,productToAdd.Adapt<ProductUserDto>());
        }
        [HttpDelete]
        public IActionResult Remove([FromQuery]int id)
        {
            var product = _productList.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _productList.Remove(product);
            return Ok();
        }
        [HttpPatch]
        public  IActionResult Update(int id ,[FromBody]JsonPatchDocument<Product> productDto)
        {
            var product = _productList.Where(x=>x.Id==id).FirstOrDefault();
            if (product==null)
            {
                return NotFound();
            }
            product.UpdatedAt = DateTime.Now;
            productDto.ApplyTo(product);
            return Ok(product);
        }
        [HttpPut]
        public IActionResult Update(ProductUpdateDto updateDto)
        {
            var product = _productList.Where(x=>x.Id==updateDto.Id).FirstOrDefault();
            if (product==null)
            {
                return NotFound();
            }
            product.UpdatedAt = DateTime.Now;
            product.Name= updateDto.Name;
            product.Price = updateDto.Price;
            product.CategoryId = updateDto.CategoryId;
            product.Id = updateDto.Id;
          
            return NoContent();
        }
    }
}
