using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapstoneAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace CapstoneAPI.Controllers
{
    [EnableCors("CORSPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly DataContext context;

        public ContactUsController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactUs>>> Get()
        {

            return Ok(await context.ContactUs.ToListAsync());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ContactUs>>> Get(int id)
        {
            var contact = await context.ContactUs.FindAsync(id);
            if (contact == null)
                return BadRequest("User Not Found");
            return Ok(contact);

        }

        [HttpPost]
        public async Task<ActionResult<List<ContactUs>>> AddContact(ContactUs contact)
        {
            context.ContactUs.Add(contact);
            await context.SaveChangesAsync();
            return Ok(await context.ContactUs.ToListAsync());

        }
    }
}
