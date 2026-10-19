using System.Text.Json;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;

namespace test_tamly.Classes;

/// <summary>
/// Phiên đăng nhập hiện tại của ứng dụng (chỉ trong bộ nhớ — không ghi ra đĩa).
/// ID token được làm mới tự động khi gọi LayIdTokenAsync().
/// </summary>
public static class PhienDangNhap
{
    public static User? NguoiDung { get; internal set; }
    public static bool DaDangNhap => NguoiDung != null;

    /// <summary>Lấy Firebase ID token (tự refresh nếu đã hết hạn) để gửi kèm Authorization: Bearer.</summary>
    public static async Task<string?> LayIdTokenAsync()
    {
        if (NguoiDung == null) return null;
        try
        {
            return await NguoiDung.GetIdTokenAsync();
        }
        catch
        {
            return null;
        }
    }

    public static void DangXuat()
    {
        NguoiDung = null;
    }
}

/// <summary>
/// Bọc FirebaseAuthentication.net (Firebase.Auth) cho đăng ký/đăng nhập Email-Password.
/// Đọc Web API Key từ Classes/firebase_config.json (file được copy kèm khi build).
/// </summary>
public static class XacThucFirebase
{
    private static readonly Lazy<FirebaseAuthClient> _client = new(() =>
    {
        var cfg = DocCauHinh();
        var config = new FirebaseAuthConfig
        {
            ApiKey = cfg.ApiKey,
            AuthDomain = cfg.AuthDomain,
            // Chỉ dùng Email/Password; không persist user ra file đĩa
            Providers = new FirebaseAuthProvider[] { new EmailProvider() },
            UserRepository = InMemoryRepository.Instance
        };
        return new FirebaseAuthClient(config);
    });

    public static FirebaseAuthClient Client => _client.Value;

    // ──────────────────────────────────────────────
    // Đọc cấu hình từ firebase_config.json (copy tới thư mục chạy)
    // ──────────────────────────────────────────────
    private sealed class CauHinhFirebase
    {
        public string ApiKey { get; set; } = "";
        public string AuthDomain { get; set; } = "";
        public string ProjectId { get; set; } = "";
    }

    private static CauHinhFirebase DocCauHinh()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Classes", "firebase_config.json");
        if (!File.Exists(path))
            throw new InvalidOperationException(
                $"Không tìm thấy {path}. Kiểm tra file Classes/firebase_config.json và cấu hình CopyToOutputDirectory.");

        var cfg = JsonSerializer.Deserialize<CauHinhFirebase>(File.ReadAllText(path),
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (cfg == null || string.IsNullOrWhiteSpace(cfg.ApiKey))
            throw new InvalidOperationException("Classes/firebase_config.json thiếu trường ApiKey.");

        return cfg;
    }

    // ──────────────────────────────────────────────
    // Đăng ký / Đăng nhập
    // ──────────────────────────────────────────────
    /// <summary>Đăng ký tài khoản Email/Password mới. Trả về User nếu thành công.</summary>
    public static async Task<User> DangKyAsync(string email, string matKhau, string hoTen)
    {
        var cred = await Client.CreateUserWithEmailAndPasswordAsync(email.Trim(), matKhau, hoTen.Trim());
        PhienDangNhap.NguoiDung = cred.User;
        return cred.User;
    }

    /// <summary>Đăng nhập Email/Password. Trả về User nếu thành công.</summary>
    public static async Task<User> DangNhapAsync(string email, string matKhau)
    {
        var cred = await Client.SignInWithEmailAndPasswordAsync(email.Trim(), matKhau);
        PhienDangNhap.NguoiDung = cred.User;
        return cred.User;
    }

    /// <summary>
    /// Dịch lỗi FirebaseAuthException sang thông báo tiếng Việt dễ hiểu cho người dùng.
    /// Không hiển thị chi tiết kỹ thuật/stack trace.
    /// </summary>
    public static string DichLoi(Exception ex)
    {
        if (ex is FirebaseAuthException fbEx)
        {
            return fbEx.Reason switch
            {
                AuthErrorReason.EmailExists => "Email này đã được đăng ký. Vui lòng dùng email khác hoặc đăng nhập.",
                AuthErrorReason.InvalidEmailAddress => "Email không hợp lệ.",
                AuthErrorReason.UserNotFound => "Không tìm thấy tài khoản với email này.",
                AuthErrorReason.WrongPassword => "Mật khẩu không đúng.",
                AuthErrorReason.WeakPassword => "Mật khẩu quá yếu (Firebase yêu cầu tối thiểu 6 ký tự).",
                AuthErrorReason.UserDisabled => "Tài khoản này đã bị vô hiệu hóa.",
                AuthErrorReason.OperationNotAllowed => "Chức năng đăng nhập Email/Password chưa được bật trong Firebase Console.",
                AuthErrorReason.TooManyAttemptsTryLater => "Thử quá nhiều lần. Vui lòng thử lại sau.",
                AuthErrorReason.InvalidApiKey => "Sai Web API Key — kiểm tra Classes/firebase_config.json.",
                AuthErrorReason.AccountExistsWithDifferentCredential =>
                    "Email này đã tồn tại với phương thức đăng nhập khác.",
                _ => $"Lỗi xác thực: {fbEx.Message}"
            };
        }

        if (ex is HttpRequestException)
            return "Không thể kết nối tới Firebase. Kiểm tra kết nối mạng.";

        if (ex is TaskCanceledException)
            return "Kết nối Firebase quá hạn (timeout). Kiểm tra kết nối mạng.";

        return $"Lỗi không xác định: {ex.Message}";
    }
}
