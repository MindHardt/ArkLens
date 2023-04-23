using Arklens.Builders;

namespace ArkLens.Snapshots;

public class CharacterSnapshot : ISnapshot<CharacterBuilder, CharacterSnapshot>
{
    public string? Name { get; set; }
    public string? Race { get; set; }
    public string? Gender { get; set; }

    public CharacterBuilder Restore() => new()
    {
        Name = Name,
        Race = Race,
        Gender = Gender
    };

    public static CharacterSnapshot FromModel(CharacterBuilder model) => new()
    {
        Name = model.Name,
        Race = model.Race,
        Gender = model.Gender
    };
}