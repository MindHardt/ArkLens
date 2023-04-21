using ArkLens.Core;

namespace ArkLens.Entities.Elements;

/// <summary>
/// A biological race of a character.
/// </summary>
public class Race : ArklensElement, IArkLensElementEnumeration<Race>
{
    protected Race(string emoji, string name) : base(emoji, name)
    {
    }

    public static Race Human { get; } = new(
        Resources.Elements.Emojis.Race_Human,
        Resources.Elements.Names.Race_Human)
    {

    };

    public static Race Elf { get; } = new(
        Resources.Elements.Emojis.Race_Elf,
        Resources.Elements.Names.Race_Elf)
    {

    };

    public static Race Dwarf { get; } = new(
        Resources.Elements.Emojis.Race_Dwarf,
        Resources.Elements.Names.Race_Dwarf)
    {

    };

    public static Race Kitsune { get; } = new(
        Resources.Elements.Emojis.Race_Kitsune,
        Resources.Elements.Names.Race_Kitsune)
    {

    };

    public static Race Minas { get; } = new(
        Resources.Elements.Emojis.Race_Minas,
        Resources.Elements.Names.Race_Minas)
    {

    };

    public static Race Serpent { get; } = new(
        Resources.Elements.Emojis.Race_Serpent,
        Resources.Elements.Names.Race_Serpent)
    {

    };

    public static IReadOnlyCollection<Race> Values { get; } = new[]
    {
        Human, Elf, Dwarf, Kitsune, Minas, Serpent
    };
}