using Microsoft.JSInterop;
using QRCoder;
using SixLabors.ImageSharp.Formats.Png;
using UnitsNet;
using Color = SixLabors.ImageSharp.Color;

namespace LabelGenerator.Components.Pages;

public partial class Home
{
    private bool IsProcessing { get; set; }
    private async Task GenerateQrCodes()
    {
        IsProcessing = true;
        await InvokeAsync(StateHasChanged);
        
        if (string.IsNullOrWhiteSpace(PersistenceService.InputValue))
        {
            PersistenceService.QrCodeItems.Clear();
            return;
        }

        // Split input by comma or newline; remove empty entries and trim
        var values = PersistenceService.InputValue?.Split([',', '\n', '\r'], StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrEmpty(x))
            .ToList();

        PersistenceService.QrCodeItems.Clear();

        if (values is null)
        {
            return;
        }
        
        foreach (var value in values)
        {
            // Convert the QR code color from settings (default to black if invalid)
            Color qrColor;
            try
            {
                qrColor = Color.ParseHex(SettingsService.QrCodeColorInput);
            }
            catch
            {
                qrColor = Color.Black;
            }

            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);

            // Generate the QR code graphic with the specified dark color and white background; no quiet zones
            using var bitmap =
                qrCode.GetGraphic(20, darkColor: qrColor, lightColor: Color.White, drawQuietZones: false);

            using var ms = new MemoryStream();
            await bitmap.SaveAsync(ms, new PngEncoder());
            var base64 = Convert.ToBase64String(ms.ToArray());
            PersistenceService.QrCodeItems.Add(new(base64, value));
        }

        await InvokeAsync(StateHasChanged);

        // After generating QR codes, immediately open the print dialog
        await JS.InvokeVoidAsync("window.print");
        
        IsProcessing = false;
    }
}