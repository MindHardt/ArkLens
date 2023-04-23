namespace ArkLens.Snapshots;

/// <summary>
/// A plain snapshot of <typeparamref name="TModel"/>
/// that can be used as database entity or
/// json model and then restored back to
/// <typeparamref name="TModel"/>.
/// </summary>
/// <typeparam name="TModel"></typeparam>
/// <typeparam name="TSelf"></typeparam>
public interface ISnapshot<TModel, out TSelf>
{
    /// <summary>
    /// Creates a new <typeparamref name="TModel"/>
    /// from this <typeparamref name="TSelf"/>.
    /// </summary>
    /// <returns>
    /// A <typeparamref name="TModel"/> with properties
    /// of this <typeparamref name="TSelf"/>.
    /// </returns>
    public TModel Restore();
    
    /// <summary>
    /// Creates a new <typeparamref name="TSelf"/>
    /// from <paramref name="model"/>.
    /// </summary>
    /// <param name="model"></param>
    /// <returns>
    /// A <typeparamref name="TSelf"/> with properties
    /// of <paramref name="model"/>.
    /// </returns>
    public static abstract TSelf FromModel(TModel model);
}