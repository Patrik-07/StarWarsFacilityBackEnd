using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/jedi")]
    public class JediController : Controller
    {
        private readonly JediFullStacAppDbContext _context;

        public JediController(JediFullStacAppDbContext jediFullStacAppDbContext) 
        {
            _context = jediFullStacAppDbContext;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllJedi()
        {
            var jediList = await _context.Jedi.ToListAsync();

            return Ok(jediList);
        }

        [HttpPost]
        public async Task<IActionResult> AddJedi([FromBody] Jedi jedi)
        {
            jedi.Id = Guid.NewGuid();

            await _context.Jedi.AddAsync(jedi);
            await _context.SaveChangesAsync();

            return Ok(jedi);
        }
    }
}
