using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

namespace AkissBot.Services;
public class GoogleSecretsService
{
    public SheetsService SheetsService { get; set; }
    public DriveService DriveService { get; set; }
    const string APPLICATION_NAME = "Akiss";
    static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets, DriveService.Scope.Drive};
    public GoogleSecretsService()
    {
        InitializeService();
    }
    private void InitializeService()
    {
        var credential = GetCredentialsFromFile();
        SheetsService = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = APPLICATION_NAME
        });
        DriveService = new DriveService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = APPLICATION_NAME
        });
    }
    private GoogleCredential GetCredentialsFromFile()
    {
        GoogleCredential credential;
        using (var stream = new FileStream("googleSecrets.json", FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
        }
        return credential;
    }
}
