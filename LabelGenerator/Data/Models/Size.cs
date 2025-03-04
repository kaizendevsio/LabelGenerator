using UnitsNet;

namespace LabelGenerator.Data.Models;

public class DynamicSize
{
    public string? DynamicWidth { get; set; }
    public string? DynamicHeight { get; set; }

    public Length? Width => Length.TryParse(DynamicWidth, out var size) ? size : null;
    public Length? Height => Length.TryParse(DynamicHeight, out var size) ? size : null;
    public Length? LongestSide => GetLongestSide();
    
    /// <summary>
    /// Returns the longest side (width or height).
    /// If one of the sides is null, it returns the non-null value.
    /// Returns null if both sides are null.
    /// </summary>
    private Length? GetLongestSide()
    {
        if (Width is null && Height is null)
        {
            return null;
        }
        if (Width is null)
        {
            return Height;
        }
        if (Height is null)
        {
            return Width;
        }

        return Width.Value > Height.Value ? Width : Height;
    }
}