# Hướng dẫn cài đặt và chạy — Test Tâm Lý

## Kiến trúc

```
WinForms (test_tamly) → ASP.NET Core Web API (TestTamLy.Api) → Firebase
```

---

## 1. Yêu cầu hệ thống

- .NET 9 SDK
- Google Cloud CLI (`gcloud`) — để dùng Application Default Credentials
- Tài khoản Google có quyền trên Firebase Project `testtamlydata`

---

## 2. Cài đặt Application Default Credentials (ADC) — Làm một lần

> Đây là bước duy nhất bạn cần làm thủ công. ADC cho phép backend xác thực với Firebase mà không cần file JSON.

```powershell
# Cài Google Cloud CLI nếu chưa có:
# https://cloud.google.com/sdk/docs/install-sdk

# Đăng nhập và tạo credentials
gcloud auth application-default login

# Đặt project mặc định (tùy chọn nhưng nên làm)
gcloud config set project testtamlydata
```

Sau bước này, credentials được lưu tại:
- Windows: `%APPDATA%\gcloud\application_default_credentials.json`

---

## 3. Kiểm tra cấu hình Firebase

File `backend/TestTamLy.Api/appsettings.json` đã cấu hình sẵn:
```json
{
  "Firebase": {
    "ProjectId": "testtamlydata"
  }
}
```
Không cần sửa gì thêm.

---

## 4. Chạy Backend

```powershell
# Từ thư mục gốc (d:\test_tamly)
dotnet run --project backend/TestTamLy.Api/

# Backend sẽ lắng nghe tại: http://localhost:5296
# (cổng lấy từ launchSettings.json — thống nhất với .env.example
#  và Classes/KetNoi.cs của WinForms)
```

> Nếu muốn đổi cổng, sửa cả ba nơi: `launchSettings.json`, `.env.example`
> (`ASPNETCORE_URLS`) và biến `TESTTAMLY_BACKEND_URL` (hoặc `KetNoi.BackendUrl`)
> phía WinForms.

---

## 5. Kiểm tra các endpoint

### Health check (không cần token)
```powershell
Invoke-RestMethod http://localhost:5296/api/health
```
Kết quả mong đợi:
```json
{ "status": "ok", "service": "TestTamLy.Api", "timestamp": "..." }
```

### Kiểm tra identity (cần token)
```powershell
# Thay <ID_TOKEN> bằng token thật lấy từ client sau khi đăng nhập
$headers = @{ Authorization = "Bearer <ID_TOKEN>" }
Invoke-RestMethod http://localhost:5296/api/me -Headers $headers
```

### Kiểm tra Firestore (cần token, dùng POST — endpoint có thao tác ghi)
```powershell
Invoke-RestMethod -Method Post http://localhost:5296/api/firestore/ping -Headers $headers
```

---

## 6. Cấu hình WinForms

WinForms đọc địa chỉ backend theo thứ tự ưu tiên:

1. Biến môi trường `TESTTAMLY_BACKEND_URL` (dễ đổi khi triển khai, không cần sửa code).
2. Mặc định `http://localhost:5296` trong `Classes/KetNoi.cs`.

```powershell
# Ví dụ đổi cổng cho phiên làm việc hiện tại
$env:TESTTAMLY_BACKEND_URL = "http://localhost:6000"
```

Cấu hình Firebase cho WinForms nằm ở `test_tamly/Classes/firebase_config.json`.

> **Lưu ý:** `firebase_config.json` đã được thêm vào `.gitignore`. Trước khi chạy WinForms lần đầu, cần tạo file này từ mẫu:
> ```powershell
> Copy-Item test_tamly\Classes\firebase_config.json.example test_tamly\Classes\firebase_config.json
> ```
> Sau đó mở file và điền Web API Key từ **Firebase Console → Project Settings → General → Web API Key** của project `testtamlydata`.


---

## 7. Build toàn bộ solution

```powershell
dotnet build test_tamly.sln
```

---

## 8. Lưu ý bảo mật

- **Không commit** file `.env`, `application_default_credentials.json`, hoặc bất kỳ Service Account JSON nào vào Git.
- `api_key.txt` hiện có chứa Firebase Web API Key — hãy xem xét thêm vào `.gitignore` hoặc chuyển sang biến môi trường.
- Backend không mở CORS vì WinForms không cần (chỉ cần nếu làm client web).
