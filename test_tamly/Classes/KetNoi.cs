using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace test_tamly.Classes;

/// <summary>
/// Lớp kết nối WinForms với Backend API (TestTamLy.Api).
/// Dùng static HttpClient để tránh socket exhaustion.
/// Đặt BackendUrl khớp với URL backend đang chạy.
/// </summary>
public static class KetNoi
{
    // ──────────────────────────────────────────────
    // Cấu hình — thay đổi ở đây nếu backend chạy cổng khác.
    // Ưu tiên cao hơn: biến môi trường TESTTAMLY_BACKEND_URL
    // (không cần sửa code khi đổi môi trường triển khai)
    // ──────────────────────────────────────────────
    private const string BackendUrlMacDinh = "http://localhost:5296";

    public static string BackendUrl { get; set; }
        = Environment.GetEnvironmentVariable("TESTTAMLY_BACKEND_URL") is { Length: > 0 } envUrl
            ? envUrl.TrimEnd('/')
            : BackendUrlMacDinh;

    // Static HttpClient — dùng chung cho toàn ứng dụng, không tạo mới mỗi request
    private static readonly HttpClient _httpClient = new HttpClient
    {
        Timeout = TimeSpan.FromSeconds(10)
    };

    // ──────────────────────────────────────────────
    // Kiểm tra backend còn sống không (không cần token)
    // ──────────────────────────────────────────────
    /// <summary>
    /// Gọi /api/health để kiểm tra backend hoạt động.
    /// Trả true nếu backend phản hồi bình thường.
    /// </summary>
    public static async Task<bool> KiemTraBackendAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BackendUrl}/api/health");
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException)
        {
            return false;
        }
        catch (TaskCanceledException)
        {
            // Timeout
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    // ──────────────────────────────────────────────
    // Gọi endpoint cần xác thực
    // ──────────────────────────────────────────────
    /// <summary>
    /// Gửi request kèm Firebase ID Token tới endpoint yêu cầu xác thực.
    /// </summary>
    /// <param name="idToken">Firebase ID Token lấy từ FirebaseAuthentication.net sau khi đăng nhập.</param>
    /// <param name="path">Ví dụ: "/api/me" hoặc "/api/firestore/ping"</param>
    /// <param name="method">Phương thức HTTP (GET/POST/...) mặc định GET.</param>
    /// <returns>Kết quả phản hồi API.</returns>
    public static async Task<ApiKetQua> GuiYeuCauCoXacThucAsync(string idToken, string path, HttpMethod? method = null)
    {
        if (string.IsNullOrWhiteSpace(idToken))
            return new ApiKetQua(false, 0, null, "idToken trống.");

        try
        {
            var httpMethod = method ?? HttpMethod.Get;
            using var request = new HttpRequestMessage(httpMethod, $"{BackendUrl}{path}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", idToken);

            var response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return new ApiKetQua(true, (int)response.StatusCode, body, null);
            else
                return new ApiKetQua(false, (int)response.StatusCode, body, $"HTTP {(int)response.StatusCode}");
        }
        catch (HttpRequestException ex)
        {
            return new ApiKetQua(false, 0, null, $"Lỗi mạng: {ex.Message}");
        }
        catch (TaskCanceledException)
        {
            return new ApiKetQua(false, 0, null, "Timeout: backend không phản hồi trong 10 giây.");
        }
        catch (Exception ex)
        {
            return new ApiKetQua(false, 0, null, $"Lỗi không xác định: {ex.Message}");
        }
    }

    // ──────────────────────────────────────────────
    // Lấy thông tin người dùng hiện tại từ backend
    // ──────────────────────────────────────────────
    /// <summary>
    /// Gọi /api/me để lấy UID và email từ token đã xác minh.
    /// </summary>
    public static async Task<ApiKetQua> LayThongTinNguoiDungAsync(string idToken)
        => await GuiYeuCauCoXacThucAsync(idToken, "/api/me");

    /// <summary>
    /// Gọi /api/firestore/ping để kiểm tra kết nối Firestore.
    /// </summary>
    public static async Task<ApiKetQua> KiemTraFirestoreAsync(string idToken)
        => await GuiYeuCauCoXacThucAsync(idToken, "/api/firestore/ping", HttpMethod.Post);
}

/// <summary>
/// Kết quả trả về từ API — bao gồm trạng thái, HTTP status code, body và thông báo lỗi.
/// </summary>
public record ApiKetQua(bool ThanhCong, int StatusCode, string? Body, string? LoiMo);
