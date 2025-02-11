using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApiContext _context;

        public MessagesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            return Ok("Mesaj Ekleme İşlemi Başarılı!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var message = _context.Messages.Find(id);
            var value = _context.Messages.Remove(message);
            _context.SaveChanges();
            return Ok("Mesaj Silme İşlemi Başarılı!");
        }

        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
            var value = _context.Messages.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateMessage(Message message)
        {
            _context.Messages.Update(message);
            _context.SaveChanges();
            return Ok("Mesaj Başarıyla Güncellendi!");
        }
    }
}
