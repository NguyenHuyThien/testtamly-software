using FirebaseAdmin.Auth;
using TestTamLy.Api.Services;

namespace TestTamLy.Api.Middleware;

/// <summary>
/// Middleware tách và xác minh Firebase ID Token từ header Authorization.
/// Nếu token hợp lệ, gắn FirebaseToken vào HttpContext.Items["FirebaseUser"].
/// Endpoint tự chọn có yêu cầu xác thực hay không — middleware không chặn request.
/// </summary>
public class FirebaseAuthMiddleware
{
    private readonly RequestDelegate _next;

    public FirebaseAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, TokenVerifier verifier)
    {
        var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
        if (authHeader != null && authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            var token = authHeader["Bearer ".Length..].Trim();
            if (!string.IsNullOrEmpty(token))
            {
                var firebaseToken = await verifier.VerifyTokenAsync(token);
                if (firebaseToken != null)
                {
                    context.Items[FirebaseAuthorizeAttribute.UserKey] = firebaseToken;
                }
            }
        }

        await _next(context);
    }
}

/// <summary>
/// Extension method để đăng ký middleware gọn hơn trong Program.cs
/// </summary>
public static class FirebaseAuthMiddlewareExtensions
{
    public static IApplicationBuilder UseFirebaseAuth(this IApplicationBuilder builder)
        => builder.UseMiddleware<FirebaseAuthMiddleware>();
}
