using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController: ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Item>>SearchItem(string searchTerm )
        {
            var query = DB.Find<Item>();
            query.Sort(x => x.Ascending(a => a.Make));
            if(!string.IsNullOrEmpty(searchTerm))
            {
                query.Match(Search.Full, searchTerm).SortByTextScore();
            }
            var result = await query.ExecuteAsync();
            return Ok(result);
        }
    }
}