using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TwitterScraper.API.Controllers
{
    [Route("api/[controller]")]
    public class HashtagsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HashtagsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return await _dbContext.Hashtags.Select(h => h.Texto).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SalvarHashtagCommand command)
        {
            if (!await _dbContext.Hashtags.AnyAsync(h => h.Texto == command.Hashtag))
            {
                _dbContext.Hashtags.Add(new Entidades.Hashtag(command.Hashtag));
                await _dbContext.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpDelete("{hashtag}")]
        public async Task<IActionResult> Delete(string hashtag)
        {
            var hashtagBanco = await _dbContext.Hashtags.FirstOrDefaultAsync(h => h.Texto == hashtag);
            if (hashtagBanco is null)
            {
                return NotFound();
            }

            _dbContext.Hashtags.Remove(hashtagBanco);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }

    public class SalvarHashtagCommand
    {
        public string Hashtag { get; set; }
    }
}
