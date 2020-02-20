using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TwitterScraper.API.Controllers
{
    [Route("api/[controller]")]
    public class HashtagsController : Controller
    {

        [HttpGet]
        public IEnumerable<string> Get()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return Guid.NewGuid().ToString();
            }
        }
    }
}
