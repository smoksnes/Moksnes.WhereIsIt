using Microsoft.AspNetCore.Mvc;
using Moksnes.WhereisIt.Business;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Moksnes.WhereIsIt.Web.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private ITitleSearcher _titleSearcher;

        public SearchController(ITitleSearcher titleSearcher)
        {
            _titleSearcher = titleSearcher;
        }


        [Route("{query}")]
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var result = await _titleSearcher.SearchAsync(query);
            return Ok(result);
        }
    }
}
