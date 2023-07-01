using Microsoft.AspNetCore.Mvc;

namespace S.SettingService.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class SettingsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetSettings()
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