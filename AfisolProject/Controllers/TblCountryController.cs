using AfisolProject.Models;
using AfisolProject.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AfisolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblCountryController : ControllerBase
    {
        private readonly ContactDbRaveenContext _context;

        public TblCountryController(ContactDbRaveenContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTblCountries()
        {
            var countryLookups = _context.TblCountries.Select(c => new ContryLookupsDTO
            {
                CountryId = c.CountryId,
                Country = c.Country
            }).ToList();

            return Ok(countryLookups);
        }



    }
}
