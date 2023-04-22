using ArkLens.Entities;
using ArkLens.Entities.Elements;

namespace Arklens.Builders;

public class CharacterBuilder : Builder<Character, CharacterBuilder>
{
    public string? Name { get; set; }
    public ArkLensElementBuilder<Race> Race = new();
    public ArkLensElementBuilder<Gender> Gender = new();

    protected override Character UnsafeBuild() => new()
    {
        Name = Name!,
        Race = Race!,
        Gender = Gender!
    };

    protected override void EnsureCompleted()
    {
        ThrowIfNull(Name, nameof(Name));
        ThrowIfNull(Race.Value, nameof(Race.Value));
        ThrowIfNull(Gender.Value, nameof(Gender.Value));
    }

    public override CharacterBuilder CopyFrom(CharacterBuilder other)
    {
        Name = other.Name;
        Race = other.Race;
        Gender = other.Gender;

        return this;
    }

    public override CharacterBuilder FillFrom(Character entity)
    {
        Name = entity.Name;
        Race = entity.Race;
        Gender = entity.Gender;

        return this;
    }
}