namespace ArkLens.Core;

/// <summary>
/// Represents enumerations with pre-defined values.
/// </summary>
/// <typeparam name="TSelf">The implementing type.</typeparam>
public interface IEnumeration<out TSelf>
    where TSelf : IEnumeration<TSelf>
{
    /// <summary>
    /// A collection of all possible values of <typeparamref name="TSelf"/>.
    /// </summary>
    public static abstract IReadOnlyCollection<TSelf> Values { get; }
}