using Google.Apis.Sheets.v4;

namespace AkissBot.Services;
public class GoogleSheetsService
{
    private readonly IConfiguration _config;
    public readonly SpreadsheetsResource.ValuesResource _googleSecretsService;
    public readonly string SpreadSheetId;
    public readonly string SheetName;
    public GoogleSheetsService(GoogleSecretsService googleSecretsService, IConfiguration config)
    {
        _googleSecretsService = googleSecretsService.SheetsService.Spreadsheets.Values;
        _config = config;
        SpreadSheetId = this._config.GetConnectionString("SheetId");
        SheetName = this._config.GetConnectionString("SheetName");
    }
}
