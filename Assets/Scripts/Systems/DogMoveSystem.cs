using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class DogMoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Translation translation, in DogMoveComponent dogMove) =>
        {
            translation.Value += dogMove.Speed * deltaTime * new float3(0, 1, 0);
        }
        ).Run();
    }
}
