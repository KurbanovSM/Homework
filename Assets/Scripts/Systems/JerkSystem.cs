using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class JerkSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((
            ref Translation translation,
            in JerkAbility JerkAbility,
            in JerkComponent jerkComponent) =>
        {
            if (jerkComponent.Jerk > 0 && JerkAbility is Iability ability)
            {
                ability.Execute();

                if (JerkAbility.IsJerk)
                {
                    float3 jerk = new float3(0, 0, JerkAbility.LenghtJerk);

                    translation.Value += jerk;
                }
            }
        }
        ).WithoutBurst().Run();
    }
}
