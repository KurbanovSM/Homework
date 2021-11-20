using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct MoveComponent : IComponentData
{
    public float Speed;

    [HideInInspector] public float2 Move;
}
