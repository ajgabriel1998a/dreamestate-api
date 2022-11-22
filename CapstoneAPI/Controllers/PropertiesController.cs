using CapstoneAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        
        private readonly DataContext context;

        public PropertiesController(DataContext context) 
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Properties>>> Get()
        {
            
            return Ok(await context.Properties.ToListAsync());
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Properties>>> Get(int id)
        {
            var property = await context.Properties.FindAsync(id);
            if (property == null)
                return BadRequest("Property Not Found");
            return Ok(property);

        }
        [HttpPost]
        public async Task<ActionResult<List<Properties>>> AddProperty(Properties property)
        {
            context.Properties.Add(property);
            await context.SaveChangesAsync();
            return Ok(await context.Properties.ToListAsync());

        }
        [HttpPut]
        public async Task<ActionResult<List<Properties>>> UpdateProperty(Properties request)
        {
            var dbproperty = await context.Properties.FindAsync(request.Id);
            if (dbproperty == null)
                return BadRequest("Property Not Found");
            dbproperty.Title = request.Title;
            dbproperty.Description = request.Description;
            dbproperty.Rooms = request.Rooms;
            dbproperty.Location = request.Location;
            dbproperty.Price = request.Price;

            await context.SaveChangesAsync();
            return Ok(await context.Properties.ToListAsync());

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Properties>>> DeleteProperty(int id)
        {
            var dbproperty = await context.Properties.FindAsync(id);
            if (dbproperty == null)
                return BadRequest("Property Not Found");
            context.Properties.Remove(dbproperty);
            await context.SaveChangesAsync();
            return Ok(await context.Properties.ToListAsync());

        }

    }
}
