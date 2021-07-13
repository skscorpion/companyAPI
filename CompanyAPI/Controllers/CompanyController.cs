using CompanyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly CompanyDBContext _context;

        public CompanyController(ILogger<CompanyController> logger, CompanyDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET api/items/5
        [HttpGet("{code}", Name = "Company")]
        public async Task<IActionResult> Get(string code)
        {
            return Ok(await _context.Companies.FirstOrDefaultAsync(f=> f.Code == code));
        }

        [HttpGet("Companies")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Companies.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Company model)
        {
            model.CreatedOn = DateTime.Now;
            model.IsActive = true;
            await _context.Companies.AddAsync(model);

            await _context.SaveChangesAsync();
            return CreatedAtRoute("Company", new { code = model.Code.ToString() }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string code, Company model)
        {
            var company = _context.Companies.Find(code);
            if (company == null)
                return BadRequest(code);

            company.CEO = model.CEO;
            company.Name = model.Name;
            company.StockExchange = model.StockExchange;
            company.TurnOver = model.TurnOver;
            company.Website = model.Website;
            
            await _context.SaveChangesAsync();
            return CreatedAtRoute("Company", new { code = model.Code.ToString() }, model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string code)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(f => f.Code == code);
            company.IsActive = false;
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
