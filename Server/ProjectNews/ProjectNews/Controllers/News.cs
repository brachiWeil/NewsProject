using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Linq;
using Web.core.Services;




namespace ProjectNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class News : ControllerBase
    {
        private readonly INewsService _service;
        public News(INewsService newsService)
        {
               _service= newsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var respon = await _service.GetNewsAsync();
            if (respon == null) 
            {
                return NotFound();
            }
            return Ok(respon);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var item = await _service.GetNewsById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

    }
}
