using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapstoneAPI.Models;

namespace CapstoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinOurTeamController : ControllerBase
    {

        private readonly DataContext context;

        public JoinOurTeamController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<JoinOurTeam>>> Get()
        {

            return Ok(await context.JoinOurTeam.ToListAsync());

        }

        [HttpPost]
        public async Task<ActionResult<List<JoinOurTeam>>> AddJoinOurTeam(JoinOurTeam join)
        {
            context.JoinOurTeam.Add(join);
            await context.SaveChangesAsync();
            return Ok(await context.JoinOurTeam.ToListAsync());

        }
    }
}
