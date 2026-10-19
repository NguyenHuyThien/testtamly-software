using FirebaseAdmin.Auth;

namespace TestTamLy.Api.Services;

/// <summary>
/// Xác minh Firebase ID Token bằng Firebase Admin SDK.
/// Token phải được lấy từ Firebase Authentication trên client.
/// </summary>
public class TokenVerifier
{
    private readonly ILogger<TokenVerifier> _logger;

    public TokenVerifier(ILogger<TokenVerifier> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Xác minh token và trả về FirebaseToken nếu hợp lệ.
    /// Trả về null nếu token không hợp lệ hoặc hết hạn — không ném ngoại lệ.
    /// </summary>
    public async Task<FirebaseToken?> VerifyTokenAsync(string idToken)
    {
        try
        {
            var decoded = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
            return decoded;
        }
        catch (FirebaseAuthException ex)
        {
            // Ghi log nhưng không để lộ thông tin thêm cho client
            _logger.LogWarning("Token không hợp lệ: {ErrorCode}", ex.AuthErrorCode);
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Lỗi khi xác minh token.");
            return null;
        }
    }
}
