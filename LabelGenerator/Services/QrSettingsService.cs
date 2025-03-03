namespace LabelGenerator.Services;

public class QrSettingsService
{
    public double PrintSizeCm { get; set; } = 5; // default printed size in cm
    public string QrCodeColorInput { get; set; } = "#000000"; // default QR code color
}