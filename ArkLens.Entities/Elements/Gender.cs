using ArkLens.Core;

namespace ArkLens.Entities.Elements;

/// <summary>
/// The binary model gender.
/// </summary>
public class Gender : ArklensElement, IArkLensElementEnumeration<Gender>
{
    protected Gender(string name, string emoji) : base(name, emoji)
    {
    }

    public static Gender Female { get; } = new(
        Resources.Elements.Emojis.Gender_Female,
        Resources.Elements.Names.Gender_Female);
    
    public static Gender Male { get; } = new(
        Resources.Elements.Emojis.Gender_Male,
        Resources.Elements.Names.Gender_Male);
    
    public static IReadOnlyCollection<Gender> Values { get; } = new[]
    {
        Female, Male
    };
}