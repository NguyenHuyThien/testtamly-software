using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;
using TestTamLy.Api.Middleware;

namespace TestTamLy.Api.Controllers;

/// <summary>
/// Trả thông tin người dùng hiện tại từ Firebase ID Token.
/// Yêu cầu header: Authorization: Bearer {idToken}
/// </summary>
[ApiController]
[Route("api/[controller]")]
[FirebaseAuthorize]
public class MeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        // Lấy FirebaseToken đã được middleware xác minh
        var firebaseUser = (FirebaseToken)HttpContext.Items[FirebaseAuthorizeAttribute.UserKey]!;

        // Không trả về thông tin nhạy cảm — chỉ trả UID và email
        return Ok(new
        {
            uid = firebaseUser.Uid,
            email = firebaseUser.Claims.TryGetValue("email", out var email) ? email : null,
            emailVerified = firebaseUser.Claims.TryGetValue("email_verified", out var ev) ? ev : null
        });
    }
}
