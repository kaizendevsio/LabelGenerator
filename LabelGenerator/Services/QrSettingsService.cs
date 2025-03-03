namespace LabelGenerator.Services;

public class QrSettingsService
{
    public double PrintSizeCm { get; set; } = 1.27; // default printed size in cm
    public string QrCodeColorInput { get; set; } = "#000000"; // default QR code color
    public bool SingleQrPerPage { get; set; }
}