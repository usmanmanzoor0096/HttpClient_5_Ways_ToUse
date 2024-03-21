using httpClient_5_Ways_ToUse.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace httpClient_5_Ways_ToUse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController(JokeService jokeService) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetJokes() => Ok( await jokeService.GetJokeAsync());
    }
}
