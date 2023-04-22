using ArkLens.Entities.Elements;

namespace ArkLens.Entities;

public record Character
{
    public required string Name { get; init; }
    public required Race Race { get; init; }
    public required Gender Gender { get; init; }
}