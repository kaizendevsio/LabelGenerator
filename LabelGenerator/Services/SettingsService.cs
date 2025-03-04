using LabelGenerator.Data.Models;
using Mapster;

namespace LabelGenerator.Services;

public class SettingsService
{
    public DynamicSize PageSize { get; init; } = new() { DynamicWidth = "8.5in", DynamicHeight = "11in" };
    private DynamicSize? PageSizeClone { get; set; } = new();
    public DynamicSize QrSize { get; init; } = new() { DynamicWidth = "1.2cm" };
    public string QrCodeColorInput { get; set; } = "#000000"; // default QR code color
    public bool SingleQrPerPage
    {
        get;
        set
        {
            if (value)
            {
                PageSizeClone = PageSize.Adapt<DynamicSize>();
                
            }
        }
    }
}