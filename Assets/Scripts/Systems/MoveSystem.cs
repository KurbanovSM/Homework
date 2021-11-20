using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class MoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var deltaTime = Time.DeltaTime;

        Entities.ForEach((
            ref Translation translation,
            in MoveComponent moveComponent) =>
        {
            float3 move = new float3(moveComponent.Move.x, 0, moveComponent.Move.y);

            translation.Value += move * moveComponent.Speed * deltaTime;
        }
        ).Run();

        Entities.ForEach((
              ref Translation translation,
            in MoveComponent moveComponent,
            in Bullet bullet) =>
        {
            float3 move = new float3(0, 0, moveComponent.Speed);

            translation.Value += move * deltaTime;
        }
        ).WithoutBurst().Run();
    }
}
