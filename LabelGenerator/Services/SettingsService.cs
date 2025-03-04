using LabelGenerator.Data.Models;
using Mapster;

namespace LabelGenerator.Services;

public class SettingsService
{
    public DynamicSize PageSize { get; set; } = new() { DynamicWidth = "1.27cm", DynamicHeight = "1.5cm" };
    private DynamicSize? PageSizeClone { get; set; } = new();
    public DynamicSize QrSize { get; init; } = new() { DynamicWidth = "1.2cm" };
    public string QrCodeColorInput { get; set; } = "#000000"; // default QR code color

    private bool _usePrinterDefaults = true;
    public bool UsePrinterDefaults
    {
        get => _usePrinterDefaults;
        set
        {
            if (value)
            {
                PageSizeClone = PageSize.Adapt<DynamicSize>();
                PageSize = new() { DynamicWidth = "1.27cm", DynamicHeight = "1.5cm" };
            }
            else
            {
                PageSize = PageSizeClone.Adapt<DynamicSize>();
            }

            _usePrinterDefaults = value;
        }
    }
}