using Unity.Entities;

[GenerateAuthoringComponent]
public struct DogMoveComponent : IComponentData
{
    public float Speed;
}
