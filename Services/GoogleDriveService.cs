using Google.Apis.Drive.v3;

namespace AkissBot.Services;
public class GoogleDriveService
{
    private readonly FilesResource _googleSecretsService;
    private readonly string FolderId = "1RuIYdRoIfCBfAX-R7_mnJLo6lj_ekeXm";
    public GoogleDriveService(GoogleSecretsService googleSecretsService, IConfiguration config)
    {
        _googleSecretsService = googleSecretsService.DriveService.Files;
    }
}
