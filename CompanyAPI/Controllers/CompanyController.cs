using CompanyAPI.DbConstants;
using CompanyAPI.Models;
using CompanyAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;
       

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
            
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var allItems = await this.companyService.GetAllAsync();
            if(allItems == null)
            {
                return NotFound();
            }
            return Ok(allItems);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var selectedItem = await this.companyService.GetByIdAsync(id);
            if(selectedItem == null)
            {
                return NotFound();
            }
            return Ok(selectedItem);
        }
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> CreateAsync([FromBody] Company company)
        {
            if(company== null)
            {
                return BadRequest();
            }
            await this.companyService.CreateAsync(company);
            return Ok("Successfully created");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Company company)
        {
            if(company == null)
            {
                return BadRequest();
            }
            if(id != company.Id)
            {
                return NotFound();
            }
            await this.companyService.UpdateAsync(id, company);
            return Ok("Successfully updated");
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteAsync(int id) 
        {
            await this.companyService.DeleteAsync(id);
            return Ok("Successfully deleted");
        }

    }
}
