using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ProductDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IValidator<Product> _validator;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> validator, ApiContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _context.Products.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok("Ürün Ekleme İşlemi Başarılı!");
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok("Ürün Silme İşlemi Başarılı!");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _context.Products.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return Ok("Ürün Güncelleme İşlemi Başarılı!");
            }
        }

        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _context.Products.Add(value);
            _context.SaveChanges();
            return Ok("Ürün Ekleme İşlemi Başarılı!");
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _context.Products.Include(x => x.Category).ToList();
            return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(values));
        }
    }
}
