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
        private readonly AppContext _dbContext;

        public HashtagsController(AppContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return await _dbContext.Hashtags.Select(h => h.Texto).ToListAsync();
        }

        [HttpPost("{hashtag}")]
        public async Task<IActionResult> Save(string hashtag)
        {
            if (!await _dbContext.Hashtags.AnyAsync(h => h.Texto == hashtag))
            {
                _dbContext.Hashtags.Add(new Entidades.Hashtag(hashtag));
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
}
