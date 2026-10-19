using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TestTamLy.Api.Middleware;

namespace TestTamLy.Api.Tests;

/// <summary>
/// Kiểm thử FirebaseAuthorizeAttribute — xác minh logic từ chối / chấp nhận request.
/// Các test này KHÔNG cần kết nối Firebase thật, chỉ kiểm tra logic attribute.
/// </summary>
public class FirebaseAuthorizeAttributeTests
{
    // ──────────────────────────────────────────────────────────
    // Helper: tạo ActionExecutingContext giả với "FirebaseUser" trong Items
    // ──────────────────────────────────────────────────────────
    private static ActionExecutingContext TaoContextGia(object? firebaseUser)
    {
        var httpContext = new DefaultHttpContext();
        if (firebaseUser != null)
            httpContext.Items[FirebaseAuthorizeAttribute.UserKey] = firebaseUser;

        var actionContext = new ActionContext(
            httpContext,
            new Microsoft.AspNetCore.Routing.RouteData(),
            new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor()
        );

        return new ActionExecutingContext(
            actionContext,
            new List<IFilterMetadata>(),
            new Dictionary<string, object?>(),
            controller: new object()
        );
    }

    // ──────────────────────────────────────────────────────────
    // Test 1: Không có token → 401 Unauthorized
    // ──────────────────────────────────────────────────────────
    [Fact(DisplayName = "Không có FirebaseUser trong Items → trả về 401 Unauthorized")]
    public void KhongCoToken_TraVe401()
    {
        // Arrange: context không có "FirebaseUser"
        var context = TaoContextGia(firebaseUser: null);
        var attribute = new FirebaseAuthorizeAttribute();

        // Act
        attribute.OnActionExecuting(context);

        // Assert
        Assert.IsType<UnauthorizedObjectResult>(context.Result);
        var result = (UnauthorizedObjectResult)context.Result;
        Assert.Equal(401, result.StatusCode);
    }

    // ──────────────────────────────────────────────────────────
    // Test 2: Có token hợp lệ → không chặn request (Result vẫn null)
    // ──────────────────────────────────────────────────────────
    [Fact(DisplayName = "Có FirebaseUser trong Items → không chặn request")]
    public void CoToken_KhongChan()
    {
        // Arrange: context có "FirebaseUser" (dùng object giả — attribute chỉ kiểm tra null)
        var fakeFirebaseUser = new object();
        var context = TaoContextGia(firebaseUser: fakeFirebaseUser);
        var attribute = new FirebaseAuthorizeAttribute();

        // Act
        attribute.OnActionExecuting(context);

        // Assert: Result phải null = không chặn request
        Assert.Null(context.Result);
    }

    // ──────────────────────────────────────────────────────────
    // Test 3: Thông báo lỗi 401 phải có trường "error"
    // ──────────────────────────────────────────────────────────
    [Fact(DisplayName = "Thông báo lỗi 401 phải chứa trường error")]
    public void Loi401_CoTruongError()
    {
        var context = TaoContextGia(firebaseUser: null);
        var attribute = new FirebaseAuthorizeAttribute();

        attribute.OnActionExecuting(context);

        var result = Assert.IsType<UnauthorizedObjectResult>(context.Result);
        // Value phải là anonymous object có thuộc tính "error"
        Assert.NotNull(result.Value);

        // Serialize kiểm tra key "error" tồn tại
        var json = System.Text.Json.JsonSerializer.Serialize(result.Value);
        Assert.Contains("error", json, StringComparison.OrdinalIgnoreCase);
    }
}
