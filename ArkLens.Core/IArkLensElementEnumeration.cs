namespace ArkLens.Core;

/// <summary>
/// And extension for <see cref="IEnumeration{TSelf}"/>
/// that adds functionality for looking up values
/// based on their <see cref="ArklensElement.Name"/>
/// and <see cref="ArklensElement.Emoji"/>.
/// </summary>
public interface IArkLensElementEnumeration<out TSelf> : IEnumeration<TSelf>
    where TSelf : ArklensElement, IArkLensElementEnumeration<TSelf>
{
    /// <summary>
    /// Gets <typeparamref name="TSelf"/> whose <see cref="ArklensElement.Name"/>
    /// is equal to <paramref name="name"/>.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="comparison">The <see cref="StringComparison"/> used to determine equality.</param>
    /// <returns></returns>
    public static TSelf? GetByName(string? name, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase) =>
        TSelf.Values.FirstOrDefault(v => v.Name.Equals(name, comparison));
    
    /// <summary>
    /// Gets <typeparamref name="TSelf"/> whose <see cref="ArklensElement.Emoji"/>
    /// is equal to <paramref name="emoji"/>.
    /// </summary>
    /// <param name="emoji"></param>
    /// <param name="comparison">The <see cref="StringComparison"/> used to determine equality.</param>
    /// <returns></returns>
    public static TSelf? GetByEmoji(string? emoji, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase) =>
        TSelf.Values.FirstOrDefault(v => v.Emoji.Equals(emoji, comparison));
}