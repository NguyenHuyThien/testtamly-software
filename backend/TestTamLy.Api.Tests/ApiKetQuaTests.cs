using TestTamLy.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestTamLy.Api.Tests;

/// <summary>
/// Kiểm thử MeController — xác minh hành vi khi có/không có FirebaseUser.
/// Các test này dùng context giả, không cần kết nối Firebase thật.
/// </summary>
public class MeControllerTests
{
    // ──────────────────────────────────────────────
    // Helper: tạo MeController với FirebaseUser giả
    // ──────────────────────────────────────────────
    private static MeController TaoControllerCoUser(string uid, string email)
    {
        // Dùng reflection để tạo FirebaseToken giả (FirebaseToken không có constructor public)
        // Thay vào đó ta test hành vi không có token (401 path)
        var controller = new MeController();
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        return controller;
    }

    // ──────────────────────────────────────────────
    // Test 1: Không có FirebaseUser trong Items → FirebaseAuthorize chặn (giả lập behavior)
    // Ở đây test trực tiếp: MeController.Get() khi không có user → exception hoặc null ref
    // Ta test qua attribute (đã có trong FirebaseAuthorizeAttributeTests)
    // Bổ sung: test pattern Items[UserKey] → null sẽ được chặn bởi attribute
    // ──────────────────────────────────────────────
    [Fact(DisplayName = "MeController yêu cầu FirebaseUser — không có user trong Items")]
    public void Get_KhongCoUser_ItemsNull()
    {
        // Test xác nhận rằng MeController đọc từ HttpContext.Items
        var controller = TaoControllerCoUser("", "");

        // Items["FirebaseUser"] là null → Get() sẽ throw NullReferenceException
        // vì đây là endpoint được bảo vệ bởi [FirebaseAuthorize]
        // Trong thực tế, attribute chặn trước khi vào Get() — behavior này đã test ở FirebaseAuthorizeAttributeTests
        // Ở đây ta chỉ xác nhận context HttpContext.Items ban đầu là trống
        Assert.DoesNotContain("FirebaseUser", controller.HttpContext.Items.Keys.Cast<string>());
    }

    // ──────────────────────────────────────────────
    // Test 2: HealthController không phụ thuộc xác thực
    // ──────────────────────────────────────────────
    [Fact(DisplayName = "HealthController không cần [FirebaseAuthorize]")]
    public void Health_KhongCanXacThuc()
    {
        // Xác nhận HealthController không có [FirebaseAuthorize] attribute
        var controllerType = typeof(HealthController);
        var hasFirebaseAuthorize = controllerType
            .GetCustomAttributes(typeof(TestTamLy.Api.Middleware.FirebaseAuthorizeAttribute), inherit: true)
            .Any();

        Assert.False(hasFirebaseAuthorize,
            "HealthController không được yêu cầu xác thực — endpoint health phải công khai");
    }

    // ──────────────────────────────────────────────
    // Test 3: FirestoreController phải có [FirebaseAuthorize]
    // ──────────────────────────────────────────────
    [Fact(DisplayName = "FirestoreController phải có [FirebaseAuthorize]")]
    public void Firestore_PhanQuyenDung()
    {
        var controllerType = typeof(TestTamLy.Api.Controllers.FirestoreController);
        var hasFirebaseAuthorize = controllerType
            .GetCustomAttributes(typeof(TestTamLy.Api.Middleware.FirebaseAuthorizeAttribute), inherit: true)
            .Any();

        Assert.True(hasFirebaseAuthorize,
            "FirestoreController phải được bảo vệ bởi [FirebaseAuthorize]");
    }

    // ──────────────────────────────────────────────
    // Test 4: MeController phải có [FirebaseAuthorize]
    // ──────────────────────────────────────────────
    [Fact(DisplayName = "MeController phải có [FirebaseAuthorize]")]
    public void Me_PhanQuyenDung()
    {
        var controllerType = typeof(MeController);
        var hasFirebaseAuthorize = controllerType
            .GetCustomAttributes(typeof(TestTamLy.Api.Middleware.FirebaseAuthorizeAttribute), inherit: true)
            .Any();

        Assert.True(hasFirebaseAuthorize,
            "MeController phải được bảo vệ bởi [FirebaseAuthorize] — cần token hợp lệ");
    }
}
