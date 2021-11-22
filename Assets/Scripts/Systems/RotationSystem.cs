using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class RotationSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var deltaTime = Time.DeltaTime;

        Entities.ForEach((
            ref Rotation rotation, 
            in MoveComponent moveComponent) =>
        {
            var inputDirection = new float3(moveComponent.Move.x, 0, moveComponent.Move.y);

            var lookDirection = math.normalizesafe(inputDirection);

            var desired = quaternion.LookRotationSafe(lookDirection, Vector3.up);

            rotation.Value = desired;
        }
        ).Run();
    }
}
