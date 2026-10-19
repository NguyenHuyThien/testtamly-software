using FirebaseAdmin.Auth;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using TestTamLy.Api.Middleware;
using TestTamLy.Api.Services;

namespace TestTamLy.Api.Controllers;

/// <summary>
/// Kiểm tra kết nối Firestore bằng thao tác đọc/ghi trên collection test riêng.
/// Không thao tác trên dữ liệu người dùng thật.
/// Yêu cầu header: Authorization: Bearer {idToken}
/// </summary>
[ApiController]
[Route("api/[controller]")]
[FirebaseAuthorize]
public class FirestoreController : ControllerBase
{
    private readonly FirebaseService _firebaseService;
    private readonly IConfiguration _config;
    private readonly ILogger<FirestoreController> _logger;

    public FirestoreController(FirebaseService firebaseService, IConfiguration config, ILogger<FirestoreController> logger)
    {
        _firebaseService = firebaseService;
        _config = config;
        _logger = logger;
    }

    /// <summary>
    /// Ghi một document test vào Firestore rồi đọc lại.
    /// Chỉ ghi đè đúng 1 document "ping" trong collection test — không tạo dữ liệu liên tục.
    /// Path: POST /api/firestore/ping
    /// </summary>
    [HttpPost("ping")]
    public async Task<IActionResult> Ping()
    {
        // UID lấy từ token đã xác minh — không nhận từ client
        var firebaseUser = (FirebaseToken)HttpContext.Items[FirebaseAuthorizeAttribute.UserKey]!;
        var collectionName = _config["BackendSettings:FirestoreTestCollection"] ?? "_ping_test";

        try
        {
            var db = _firebaseService.Firestore;
            var docRef = db.Collection(collectionName).Document("ping");

            // Ghi
            var writeData = new Dictionary<string, object>
            {
                { "timestamp", Timestamp.GetCurrentTimestamp() },
                { "by", firebaseUser.Uid }
            };
            await docRef.SetAsync(writeData);

            // Đọc lại
            var snapshot = await docRef.GetSnapshotAsync();

            if (!snapshot.Exists)
            {
                return StatusCode(500, new { error = "Ghi Firestore thành công nhưng không đọc được document." });
            }

            _logger.LogInformation("Firestore ping thành công bởi UID: {Uid}", firebaseUser.Uid);

            return Ok(new
            {
                status = "ok",
                firestoreConnected = true,
                document = collectionName + "/ping",
                timestamp = snapshot.GetValue<Timestamp>("timestamp").ToDateTime()
            });
        }
        catch (Exception ex)
        {
            // Không trả stack trace cho client
            _logger.LogError(ex, "Lỗi Firestore ping.");
            return StatusCode(500, new { error = "Không thể kết nối Firestore. Xem log backend để biết thêm." });
        }
    }
}
