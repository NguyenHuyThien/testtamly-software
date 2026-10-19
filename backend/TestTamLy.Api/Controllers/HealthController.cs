using Microsoft.AspNetCore.Mvc;

namespace TestTamLy.Api.Controllers;

/// <summary>
/// Kiểm tra tình trạng hoạt động của backend.
/// Không yêu cầu xác thực — dùng để WinForms ping lúc khởi động.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "ok",
            timestamp = DateTimeOffset.UtcNow,
            service = "TestTamLy.Api"
        });
    }
}
