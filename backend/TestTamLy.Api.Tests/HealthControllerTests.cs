using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using TestTamLy.Api.Controllers;

namespace TestTamLy.Api.Tests;

/// <summary>
/// Kiểm thử HealthController — không cần kết nối Firebase hay database.
/// </summary>
public class HealthControllerTests
{
    // ──────────────────────────────────────────────
    // Test 1: GET /api/health → 200 OK
    // ──────────────────────────────────────────────
    [Fact(DisplayName = "GET /api/health → trả về 200 OK")]
    public void Health_TraVe200()
    {
        // Arrange
        var controller = new HealthController();
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = controller.Get();

        // Assert
        var ok = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, ok.StatusCode);
    }

    // ──────────────────────────────────────────────
    // Test 2: Response phải có trường "status" = "ok"
    // ──────────────────────────────────────────────
    [Fact(DisplayName = "GET /api/health → body có status=ok")]
    public void Health_CoTruongStatusOk()
    {
        var controller = new HealthController();
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        var result = controller.Get();
        var ok = Assert.IsType<OkObjectResult>(result);

        // Serialize để kiểm tra trường status
        var json = System.Text.Json.JsonSerializer.Serialize(ok.Value);
        Assert.Contains("\"status\"", json, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("ok", json, StringComparison.OrdinalIgnoreCase);
    }

    // ──────────────────────────────────────────────
    // Test 3: Response phải có trường "timestamp" (không rỗng)
    // ──────────────────────────────────────────────
    [Fact(DisplayName = "GET /api/health → body có trường timestamp")]
    public void Health_CoTruongTimestamp()
    {
        var controller = new HealthController();
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        var result = controller.Get();
        var ok = Assert.IsType<OkObjectResult>(result);

        var json = System.Text.Json.JsonSerializer.Serialize(ok.Value);
        Assert.Contains("timestamp", json, StringComparison.OrdinalIgnoreCase);
    }

    // ──────────────────────────────────────────────
    // Test 4: Response phải có trường "service" 
    // ──────────────────────────────────────────────
    [Fact(DisplayName = "GET /api/health → body có trường service")]
    public void Health_CoTruongService()
    {
        var controller = new HealthController();
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        var result = controller.Get();
        var ok = Assert.IsType<OkObjectResult>(result);

        var json = System.Text.Json.JsonSerializer.Serialize(ok.Value);
        Assert.Contains("service", json, StringComparison.OrdinalIgnoreCase);
    }
}
