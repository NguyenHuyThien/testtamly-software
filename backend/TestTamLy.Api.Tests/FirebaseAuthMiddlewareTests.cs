using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using TestTamLy.Api.Middleware;
using TestTamLy.Api.Services;

namespace TestTamLy.Api.Tests;

/// <summary>
/// Kiểm thử FirebaseAuthMiddleware — xác minh middleware tách token đúng cách
/// và không để lộ thông tin nhạy cảm khi token không hợp lệ.
/// Các test này dùng TokenVerifier giả (fake) — không gọi Firebase thật.
/// </summary>
public class FirebaseAuthMiddlewareTests
{
    // ──────────────────────────────────────────────────────────
    // Test 1: Header không có Bearer → Items["FirebaseUser"] phải null
    // ──────────────────────────────────────────────────────────
    [Fact(DisplayName = "Không có header Authorization → FirebaseUser không được gắn vào Items")]
    public async Task KhongCoHeader_KhongGanUser()
    {
        // Arrange
        var httpContext = new DefaultHttpContext();
        httpContext.Items.Clear();

        bool nextCalled = false;
        RequestDelegate next = ctx => { nextCalled = true; return Task.CompletedTask; };

        var middleware = new FirebaseAuthMiddleware(next);
        var fakeVerifier = new FakeTokenVerifier(traVeNull: true);

        // Act
        await middleware.InvokeAsync(httpContext, fakeVerifier);

        // Assert
        Assert.Null(httpContext.Items[FirebaseAuthorizeAttribute.UserKey]);
        Assert.True(nextCalled, "Middleware phải gọi next() ngay cả khi không có token");
    }

    // ──────────────────────────────────────────────────────────
    // Test 2: Header có "Bearer INVALID" → verifier trả null → không gắn user
    // ──────────────────────────────────────────────────────────
    [Fact(DisplayName = "Token không hợp lệ → FirebaseUser không được gắn vào Items")]
    public async Task TokenKhongHopLe_KhongGanUser()
    {
        // Arrange
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers.Authorization = "Bearer token_gia_khong_hop_le";

        bool nextCalled = false;
        RequestDelegate next = ctx => { nextCalled = true; return Task.CompletedTask; };

        var middleware = new FirebaseAuthMiddleware(next);
        var fakeVerifier = new FakeTokenVerifier(traVeNull: true); // Giả lập token sai

        // Act
        await middleware.InvokeAsync(httpContext, fakeVerifier);

        // Assert
        Assert.Null(httpContext.Items[FirebaseAuthorizeAttribute.UserKey]);
        Assert.True(nextCalled);
    }

    // ──────────────────────────────────────────────────────────
    // Test 3: Header "Bearer" không có token sau đó → không crash
    // ──────────────────────────────────────────────────────────
    [Fact(DisplayName = "Header Authorization chỉ có Bearer không có token → không crash")]
    public async Task BearerKhongCoToken_KhongCrash()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers.Authorization = "Bearer ";

        RequestDelegate next = ctx => Task.CompletedTask;
        var middleware = new FirebaseAuthMiddleware(next);
        var fakeVerifier = new FakeTokenVerifier(traVeNull: true);

        // Không được throw exception
        var ex = await Record.ExceptionAsync(() => middleware.InvokeAsync(httpContext, fakeVerifier));
        Assert.Null(ex);
    }

    // ──────────────────────────────────────────────────────────
    // Test 4: Middleware phải tiếp tục pipeline (gọi next) dù không có token
    // ──────────────────────────────────────────────────────────
    [Fact(DisplayName = "Middleware không chặn request — luôn gọi next() pipeline")]
    public async Task LuonGoiNext()
    {
        var httpContext = new DefaultHttpContext();
        // Không set Authorization header

        bool nextCalled = false;
        RequestDelegate next = ctx => { nextCalled = true; return Task.CompletedTask; };

        var middleware = new FirebaseAuthMiddleware(next);
        var fakeVerifier = new FakeTokenVerifier(traVeNull: true);

        await middleware.InvokeAsync(httpContext, fakeVerifier);

        Assert.True(nextCalled, "Middleware phải tiếp tục gọi next() trong pipeline");
    }
}

/// <summary>
/// Fake TokenVerifier — thay thế Firebase trong test để không cần kết nối mạng.
/// </summary>
internal class FakeTokenVerifier : TokenVerifier
{
    private readonly bool _traVeNull;

    public FakeTokenVerifier(bool traVeNull)
        : base(NullLogger<TokenVerifier>.Instance)
    {
        _traVeNull = traVeNull;
    }

    public override Task<FirebaseAdmin.Auth.FirebaseToken?> VerifyTokenAsync(string idToken)
    {
        // Nếu traVeNull = true: giả lập token không hợp lệ
        // Nếu traVeNull = false: không thể mock FirebaseToken thật (sealed) — chỉ dùng trong test null path
        return Task.FromResult<FirebaseAdmin.Auth.FirebaseToken?>(null);
    }
}
