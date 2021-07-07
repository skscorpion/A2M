using Company.Models;
using Company.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CompanyController> _logger;
        private readonly CompanyService _cosmosDbService;

        public CompanyController(ILogger<CompanyController> logger, CompanyService cosmosDbService)
        {
            _logger = logger;
            _cosmosDbService = cosmosDbService ?? throw new ArgumentNullException(nameof(cosmosDbService));
        }

        // GET api/items/5
        [HttpGet("{code}", Name = "Company")]
        public async Task<IActionResult> Get(string code)
        {
            return Ok(_cosmosDbService.Get(code));
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] CompanyModel item)
        //{
        //    item.Code = "test";
        //    await _cosmosDbService.AddAsync(item);
        //    return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        //}

        [HttpPost]
        public ActionResult<CompanyModel> Create(CompanyModel book)
        {
            _cosmosDbService.Create(book);

            return CreatedAtRoute("Company", new { code = book.Code.ToString() }, book);
        }
    }
}
