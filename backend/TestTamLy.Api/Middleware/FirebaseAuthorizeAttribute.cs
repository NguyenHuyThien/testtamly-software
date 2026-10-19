using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestTamLy.Api.Middleware;

/// <summary>
/// Thuộc tính xác thực tập trung cho controller/action.
/// Đặt [FirebaseAuthorize] lên action hoặc controller yêu cầu đăng nhập —
/// không cần mỗi controller tự kiểm tra token thủ công.
/// FirebaseAuthMiddleware đã xác minh token và gắn FirebaseUser vào HttpContext.Items;
/// attribute này từ chối request nếu không có user hợp lệ.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public sealed class FirebaseAuthorizeAttribute : ActionFilterAttribute
{
    public const string UserKey = "FirebaseUser";

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.HttpContext.Items[UserKey] == null)
        {
            context.Result = new UnauthorizedObjectResult(new
            {
                error = "Token không hợp lệ, hết hạn hoặc chưa cung cấp."
            });
            return;
        }

        base.OnActionExecuting(context);
    }
}
