using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;

namespace TestTamLy.Api.Services;

/// <summary>
/// Khởi tạo Firebase Admin App một lần duy nhất dùng Application Default Credentials (ADC).
/// Không cần Service Account JSON file — chạy `gcloud auth application-default login` trên máy dev.
/// </summary>
public class FirebaseService
{
    public FirebaseApp App { get; }
    public FirestoreDb Firestore { get; }

    public FirebaseService(IConfiguration config)
    {
        var projectId = config["Firebase:ProjectId"]
            ?? throw new InvalidOperationException("Firebase:ProjectId chưa được cấu hình trong appsettings.json");

        // Khởi tạo FirebaseApp với ADC (Application Default Credentials)
        // Tìm credentials theo thứ tự: GOOGLE_APPLICATION_CREDENTIALS env → gcloud ADC → Workload Identity
        if (FirebaseApp.DefaultInstance == null)
        {
            var credential = GoogleCredential.GetApplicationDefault(); // chỉ gọi một lần
            App = FirebaseApp.Create(new AppOptions
            {
                Credential = credential,
                ProjectId = projectId
            });
        }
        else
        {
            App = FirebaseApp.DefaultInstance;
        }

        // Khởi tạo Firestore dùng cùng project
        Firestore = new FirestoreDbBuilder
        {
            ProjectId = projectId
        }.Build();
    }
}
