using ArkLens.Entities;

namespace Arklens.Builders;

public class CharacterBuilder : Builder<Character, CharacterBuilder>
{
    public string? Name { get; set; }
    
    protected override Character UnsafeBuild() => new()
    {
        Name = Name!
    };

    protected override void EnsureCompleted()
    {
        ThrowIfNull(Name, nameof(Name));
    }

    public override CharacterBuilder CopyFrom(CharacterBuilder other)
    {
        Name = other.Name;

        return this;
    }

    public override CharacterBuilder FillFrom(Character entity)
    {
        Name = entity.Name;

        return this;
    }
}