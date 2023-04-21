using ArkLens.Resources.Errors;

namespace Arklens.Builders;

/// <summary>
/// Represents a builder for <typeparamref name="TEntity"/>.
/// </summary>
/// <typeparam name="TEntity">The built entity, typically immutable.</typeparam>
/// <typeparam name="TSelf">The implementing type.</typeparam>
public abstract class Builder<TEntity, TSelf>
    where TSelf : Builder<TEntity, TSelf>, new()
{
    /// <summary>
    /// Tries to build <typeparamref name="TEntity"/> from this
    /// <typeparamref name="TSelf"/>. This method expects that data is validated by
    /// <see cref="EnsureCompleted"/> and is not expected to throw.
    /// </summary>
    /// <returns></returns>
    protected abstract TEntity UnsafeBuild();
    
    /// <summary>
    /// Ensures that all the necessary fields of
    /// this <typeparamref name="TSelf"/> are set.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// When fields fail validation.
    /// </exception>
    protected abstract void EnsureCompleted();
    
    /// <summary>
    /// Tries to build <typeparamref name="TEntity"/> from this <typeparamref name="TSelf"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// When fields fail validation.
    /// </exception>
    /// <returns></returns>
    public TEntity Build()
    {
        EnsureCompleted();
        return UnsafeBuild();
    }
    
    /// <summary>
    /// Sets fields of this <typeparamref name="TSelf"/>
    /// from the values of <paramref name="other"/>.
    /// </summary>
    /// <param name="other"></param>
    /// <returns>Reference to the same instance.</returns>
    public abstract TSelf CopyFrom(TSelf other);

    /// <summary>
    /// Sets fields of this <typeparamref name="TSelf"/>
    /// from the values of <paramref name="entity"/>.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Reference to the same instance.</returns>
    public abstract TSelf FillFrom(TEntity entity);

    /// <summary>
    /// Creates a new <typeparamref name="TSelf"/> from
    /// <paramref name="entity"/>.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static TSelf FromEntity(TEntity entity)
        => new TSelf().FillFrom(entity);
    
    /// <summary>
    /// Throws formatted and localized <see cref="InvalidOperationException"/>.
    /// </summary>
    /// <param name="paramName">Name of the incomplete field.</param>
    /// <exception cref="InvalidOperationException"></exception>
    protected void ThrowFieldIncomplete(string paramName)
        => throw new InvalidOperationException(string.Format(Errors.FieldMissingValue, paramName));
    
    /// <summary>
    /// Throws formatted and localized <see cref="InvalidOperationException"/>
    /// if <paramref name="value"/> is <see langword="null"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    protected void ThrowIfNull(object? value, string paramName)
    {
        if (value is null) ThrowFieldIncomplete(paramName);
    }
}