using TestTamLy.Api.Middleware;
using TestTamLy.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// ──────────────────────────────────────────────
// Đăng ký Services
// ──────────────────────────────────────────────
builder.Services.AddControllers();

// FirebaseService: Singleton — chỉ khởi tạo một lần, dùng ADC
builder.Services.AddSingleton<FirebaseService>();

// TokenVerifier: Scoped — dùng FirebaseAuth đã khởi tạo bởi FirebaseService
builder.Services.AddScoped<TokenVerifier>();

// ──────────────────────────────────────────────
// Build app
// ──────────────────────────────────────────────
var app = builder.Build();

// Khởi tạo Firebase sớm để phát hiện lỗi cấu hình ngay khi khởi động
// (không phải lần đầu tiên có request)
try
{
    _ = app.Services.GetRequiredService<FirebaseService>();
    app.Logger.LogInformation("Firebase Admin SDK đã khởi tạo thành công.");
}
catch (Exception ex)
{
    app.Logger.LogCritical(ex, "Không thể khởi tạo Firebase Admin SDK. Kiểm tra ADC bằng: gcloud auth application-default login");
    // Vẫn cho app chạy để /api/health còn trả được lỗi cụ thể
}

// ──────────────────────────────────────────────
// Middleware pipeline
// ──────────────────────────────────────────────
app.UseFirebaseAuth(); // Tách và xác minh Bearer token trước các controller

app.MapControllers();

app.Run();
