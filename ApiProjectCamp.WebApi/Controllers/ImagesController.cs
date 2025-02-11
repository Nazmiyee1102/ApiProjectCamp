using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ApiContext _context;

        public ImagesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ImageList()
        {
            var values = _context.Images.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateImage(Image image)
        {
            _context.Images.Add(image);
            _context.SaveChanges();
            return Ok("Resim Ekleme İşlemi Başarılı!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteImage(int id)
        {
            var image = _context.Images.Find(id);
            var value = _context.Images.Remove(image);
            _context.SaveChanges();
            return Ok("Resim Silme İşlemi Başarılı!");
        }

        [HttpGet("GetImage")]
        public IActionResult GetImage(int id)
        {
            var value = _context.Images.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateImage(Image image)
        {
            _context.Images.Update(image);
            _context.SaveChanges();
            return Ok("Resim Başarıyla Güncellendi!");
        }
    }
}
