using Microsoft.AspNetCore.Mvc;

namespace S.UserService.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        await Task.Delay(TimeSpan.FromSeconds(0));

        return Ok(new[]
        {
            new {Id = 1},
            new {Id = 2},
            new {Id = 3}
        });
    }
}