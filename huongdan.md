# YÊU CẦU TRIỂN KHAI BACKEND FIREBASE — TEST TÂM LÝ

## 1. Bối cảnh dự án

Tôi đang phát triển phần mềm Test Tâm Lý bằng C# Windows Forms, hiện sử dụng .NET 9.

Cấu trúc hiện có do Visual Studio tạo. Tôi chỉ bổ sung ba thư mục:
- `audio`: lưu tài nguyên âm thanh.
- `classes`: chứa các lớp xử lý và dữ liệu.
- `form`: chứa các Form giao diện.

Đã tạo lớp `classes/KetNoi.cs`.

Đã tạo Firebase Project, đăng ký Web App, bật Firebase Authentication bằng Email/Password và tạo Cloud Firestore database `(default)`.

Các NuGet package đã cài trong project WinForms:
- `FirebaseAuthentication.net`
- `Google.Cloud.Firestore`

## 2. Mục tiêu

Triển khai mô hình:

WinForms (.NET 9) → ASP.NET Core Web API (.NET 9) → Firebase.

Backend có nhiệm vụ xác minh danh tính, kiểm tra quyền và xử lý các thao tác dữ liệu cần thiết.

Không nhúng Service Account private key hoặc thông tin xác thực quản trị vào ứng dụng WinForms.

## 3. Quy tắc thực hiện

1. Kiểm tra toàn bộ cấu trúc thư mục, file `.csproj`, `Program.cs`, `KetNoi.cs` và cấu hình hiện tại trước khi sửa.
2. Tái sử dụng code hiện có nếu phù hợp; không tự ý xóa hoặc viết lại giao diện WinForms.
3. Giữ nguyên tên và cấu trúc ba thư mục `audio`, `classes`, `form`.
4. Nếu thiếu project backend, tạo ASP.NET Core Web API .NET 9 tại `backend/TestTamLy.Api`.
5. Không tạo thêm project hoặc file trùng lặp nếu đã có thành phần tương đương.
6. Chọn các NuGet package tương thích với .NET 9; kiểm tra API thực tế của phiên bản package trước khi sử dụng.
7. Không giả định `FirebaseAuthentication.net` cung cấp một API cụ thể khi chưa kiểm tra tài liệu hoặc code đã cài.
8. Tự động khôi phục package và build từng project; sửa các lỗi phát sinh trong phạm vi yêu cầu.
9. Không chỉ tạo code mẫu hoặc TODO. Hoàn thiện chức năng tối thiểu, có xử lý lỗi và hướng dẫn chạy.
10. Không yêu cầu người dùng thực hiện lại các thao tác đã hoàn thành.

## 4. Xác thực và bảo mật

### WinForms
- Dùng Firebase Authentication Email/Password để đăng ký và đăng nhập.
- Lấy Firebase ID token sau khi đăng nhập thành công.
- Gửi ID token qua header `Authorization: Bearer <token>` khi gọi API cần xác thực.
- Không gửi mật khẩu đến backend dưới dạng tự xây dựng hoặc tự lưu mật khẩu.
- Không ghi mật khẩu, ID token hoặc refresh token vào log.

### Backend
- Tạo ASP.NET Core Web API.
- Dùng Firebase Admin SDK để xác minh Firebase ID token do client gửi.
- Chỉ xử lý yêu cầu đã xác minh danh tính đối với endpoint cần đăng nhập.
- Kiểm tra quyền người dùng tại backend; không tin dữ liệu quyền do client tự gửi.
- Dùng Google Cloud Firestore SDK để truy cập Firestore từ backend.
- Cấu hình Application Default Credentials hoặc Service Account theo hướng dẫn chính thức của Google.
- Không commit Service Account JSON, private key, mật khẩu hoặc bí mật vào Git.
- Không đặt khóa quản trị trong ứng dụng WinForms.
- Xử lý lỗi xác thực, lỗi mạng và lỗi Firestore an toàn; không trả stack trace hoặc thông tin bí mật cho client.
- Cấu hình CORS chỉ khi thực sự cần cho client web; WinForms không cần mở CORS chỉ để gọi API.
- Không mở rộng quyền IAM quá mức cần thiết.

## 5. Chức năng tối thiểu cần triển khai

### Backend
1. Endpoint kiểm tra tình trạng hoạt động, không yêu cầu đăng nhập.
2. Endpoint kiểm tra danh tính hiện tại, yêu cầu Firebase ID token hợp lệ.
3. Endpoint thử đọc hoặc ghi một tài liệu Firestore phục vụ kiểm tra kết nối; không thao tác trên dữ liệu người dùng thật.
4. Tách phần xác minh token, cấu hình Firebase và xử lý Firestore thành các thành phần dễ bảo trì.
5. Đọc cấu hình từ biến môi trường hoặc hệ thống cấu hình phù hợp.
6. Trả HTTP status code và thông báo lỗi rõ ràng, không làm lộ bí mật.

### WinForms
1. Hoàn thiện `classes/KetNoi.cs` để gọi Backend API qua `HttpClient`.
2. Quản lý `HttpClient` hợp lý, tránh tạo mới liên tục cho từng request.
3. Có phương thức kiểm tra backend và gửi token khi gọi endpoint cần xác thực.
4. Xử lý timeout, lỗi mạng, HTTP status code và JSON response.
5. Không tự ý sửa luồng đăng nhập/đăng ký của Form khi chưa kiểm tra code hiện tại.
6. Nếu cần thay đổi Form để tích hợp, giữ nguyên tên control và bố cục hiện có.

## 6. Firestore và dữ liệu người dùng

- Chưa tự thiết kế hoặc thay đổi schema dữ liệu chính thức khi chưa kiểm tra các model hiện có.
- Không lưu mật khẩu người dùng trong Firestore.
- Không cho phép client tùy ý chọn UID để đọc hoặc ghi dữ liệu của người khác.
- Nếu cần lưu hồ sơ người dùng, gắn dữ liệu với UID lấy từ ID token đã xác minh.
- Thiết lập Firestore Security Rules phù hợp; không bật quyền đọc/ghi công khai để khắc phục lỗi kết nối.
- Nếu backend dùng Admin SDK, hiểu rằng Admin SDK có thể bỏ qua Firestore Security Rules; do đó phải kiểm tra quyền trong backend và giới hạn IAM.

## 7. Cấu hình triển khai

Tạo file mẫu cấu hình không chứa bí mật thực tế, ví dụ `.env.example` hoặc tài liệu biến môi trường, phù hợp với công nghệ được chọn.

Cung cấp hướng dẫn:
- Cấu hình Firebase Project ID.
- Cấu hình Application Default Credentials hoặc Service Account an toàn.
- Chạy backend ở môi trường phát triển.
- Cấu hình URL backend cho WinForms.
- Chạy thử endpoint kiểm tra sức khỏe.
- Kiểm tra ID token.
- Kiểm tra kết nối Firestore.

Không yêu cầu người dùng cung cấp private key qua chat.

## 8. Kiểm thử và nghiệm thu

Sau khi triển khai:
1. Build backend.
2. Build WinForms.
3. Kiểm tra endpoint health.
4. Kiểm tra endpoint có token hợp lệ và token không hợp lệ.
5. Kiểm tra thao tác Firestore trong môi trường thử nghiệm.
6. Kiểm tra các trường hợp backend không hoạt động, timeout và lỗi xác thực.
7. Liệt kê file mới tạo và file đã sửa.
8. Báo rõ các bước đã thực sự chạy thành công và các bước chưa thể kiểm thử.
9. Không tuyên bố kết nối Firebase thành công nếu chưa chạy kiểm thử thực tế.

## 9. Báo cáo cuối cùng

Trả về báo cáo ngắn gọn gồm:
- Kiến trúc cuối cùng.
- Các file đã tạo/sửa.
- Các NuGet package đã dùng và phiên bản.
- Kết quả build/test.
- Các biến môi trường cần cấu hình.
- Lệnh chạy backend và cách kiểm tra.
- Các việc còn cần tôi thực hiện thủ công trên Firebase Console hoặc máy phát triển.

Ưu tiên triển khai hoàn chỉnh, an toàn, ít thao tác thủ công và dễ bảo trì. Nếu phát hiện yêu cầu kỹ thuật không tương thích hoặc thiếu thông tin bắt buộc, hãy nêu rõ vấn đề và chọn phương án an toàn phù hợp thay vì tự tạo cấu hình giả.
