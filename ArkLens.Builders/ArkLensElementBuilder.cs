using ArkLens.Core;

namespace Arklens.Builders;

/// <summary>
/// A builder that allows setting names of <typeparamref name="TElement"/>
/// and retrieving values as well as implicit conversions.
/// This class is expected to be used in other
/// <see cref="Builder{TEntity,TSelf}"/> implementations. This class cannot be
/// inherited.
/// </summary>
/// <typeparam name="TElement"></typeparam>
public sealed class ArkLensElementBuilder<TElement> : 
    Builder<TElement, ArkLensElementBuilder<TElement>>
    where TElement : ArklensElement, IArkLensElementEnumeration<TElement>
{
    private string? _name;
    private TElement? _value;

    public string? Name
    {
        get => _name;
        set
        {
            _name = value;
            _value = IArkLensElementEnumeration<TElement>.GetByName(_name);
        }
    }

    public TElement? Value
    {
        get => _value;
        set
        {
            _value = value;
            _name = _value?.Name;
        }
    }

    protected override TElement UnsafeBuild() => Value!;

    protected override void EnsureCompleted() => ThrowIfNull(Value, nameof(Value));

    public override ArkLensElementBuilder<TElement> CopyFrom(ArkLensElementBuilder<TElement> other)
    {
        Value = other.Value;
        return this;
    }

    public override ArkLensElementBuilder<TElement> FillFrom(TElement entity)
    {
        Value = entity;
        return this;
    }

    public static ArkLensElementBuilder<TElement> FromName(string? name)
        => new() { Name = name };
    
    public static ArkLensElementBuilder<TElement> FromValue(TElement? value)
        => new() { Value = value };

    public static implicit operator TElement?(ArkLensElementBuilder<TElement> builder)
        => builder.Value;
    
    public static implicit operator string?(ArkLensElementBuilder<TElement> builder)
        => builder.Name;

    public static implicit operator ArkLensElementBuilder<TElement>(TElement? value)
        => FromValue(value);
    
    public static implicit operator ArkLensElementBuilder<TElement>(string? name)
        => FromName(name);

}