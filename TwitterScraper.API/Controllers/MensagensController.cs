using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwitterScraper.API.Entidades;
using TwitterScraper.API.ViewModels;

namespace TwitterScraper.API.Controllers
{
    [Route("api/[controller]")]
    public class MensagensController : Controller
    {
        private readonly AppDbContext _dbContext;

        public MensagensController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<MensagemViewModel>> Get([FromQuery] string hashtags)
        {
            var hashtagFilters = hashtags?.Split('|');
            IQueryable<Mensagem> query = _dbContext.Mensagens;
            if (hashtagFilters?.Length > 0)
            {
                query = query
                    .Include(m => m.MensagemHashtags)
                    .Where(m => m.MensagemHashtags.Any(mh => hashtagFilters.Any(h => h == mh.Hashtag)));
            }

            return await query
                .Select(m => new MensagemViewModel(m.Autor, m.DataPublicacao, m.Texto))
                .ToListAsync();
        }
    }
}
