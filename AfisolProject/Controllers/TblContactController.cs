using AfisolProject.Models;
using AfisolProject.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AfisolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblContactController : ControllerBase
    {
        private readonly ContactDbRaveenContext _context;

        public TblContactController(ContactDbRaveenContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddContactDTO>>> GetTblContacts()
        {
            var contactsDto = await _context.TblContacts.Select(c => new AddContactDTO
            {
                ContactId = c.ContactId,
                Name = c.Name,
                Address = c.Address,
                Tel = c.Tel,
                Mobile = c.Mobile,
                Email = c.Email,
                CountryId = c.CountryId
            }).ToListAsync();

            return Ok(contactsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddContactDTO>> GetTblContact(int id)
        {
            var tblContact = await _context.TblContacts.FindAsync(id);

            if (tblContact == null)
            {
                return NotFound();
            }

            
            var contactDto = new AddContactDTO
            {
                ContactId = tblContact.ContactId,
                Name = tblContact.Name,
                Address = tblContact.Address,
                Tel = tblContact.Tel,
                Mobile = tblContact.Mobile,
                Email = tblContact.Email,
                CountryId = tblContact.CountryId
            };

            return contactDto;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AddContactDTO contactDto)
        {
            try
            {
                var tblContact = await _context.TblContacts.FindAsync(id);

                if (tblContact == null)
                {
                    return NotFound();
                }

               
                tblContact.Name = contactDto.Name;
                tblContact.Address = contactDto.Address;
                tblContact.Tel = contactDto.Tel;
                tblContact.Mobile = contactDto.Mobile;
                tblContact.Email = contactDto.Email;
                tblContact.CountryId = contactDto.CountryId;

                _context.SaveChanges();
                return Ok();

               
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<AddContactDTO>> Post([FromBody] AddContactDTO contactDto)
        {
            try
            {
                var tblContact = new TblContact
                {
                    Name = contactDto.Name,
                    Address = contactDto.Address,
                    Tel = contactDto.Tel,
                    Mobile = contactDto.Mobile,
                    Email = contactDto.Email,
                    CountryId = contactDto.CountryId
                };

                _context.TblContacts.Add(tblContact);
                _context.SaveChanges();
                return Ok();

                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tblContact = await _context.TblContacts.FindAsync(id);

                if (tblContact == null)
                {
                    return NotFound();
                }

                _context.TblContacts.Remove(tblContact);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
