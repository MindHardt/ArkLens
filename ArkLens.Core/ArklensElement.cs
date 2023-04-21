namespace ArkLens.Core;

/// <summary>
/// A base class for character parts with string and emoji representations.
/// </summary>
public abstract class ArklensElement : IEquatable<ArklensElement>
{
    /// <summary>
    /// The emoji component of this <see cref="ArklensElement"/>.
    /// It is meant to be unique per-type.
    /// </summary>
    public string Emoji { get; }
    /// <summary>
    /// The name of this <see cref="ArklensElement"/>.
    /// It is meant to be unique per type.
    /// </summary>
    public string Name { get; }

    public ArklensElement(string emoji, string name)
    {
        Emoji = emoji;
        Name = name;
    }

    public override string ToString() => 
        $"[{Emoji} {Name}]";

    public bool Equals(ArklensElement? other) =>
        ReferenceEquals(this, other) ||
        other is not null &&
        Emoji == other.Emoji &&
        Name == other.Name;

    public override bool Equals(object? obj) =>
        ReferenceEquals(this, obj) ||
        obj is ArklensElement other &&
        Equals(other);

    public override int GetHashCode() => 
        HashCode.Combine(Emoji, Name);
}