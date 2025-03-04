using LabelGenerator.Data.Models;

namespace LabelGenerator.Services;

public class PersistenceService
{
    public List<QrCodeItem> QrCodeItems = [];
    public string? InputValue { get; set; }
}