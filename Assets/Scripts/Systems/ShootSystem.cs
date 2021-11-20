using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class ShootSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((
            in ShootAbility shootAbility,
            in ShootComponent shootComponent) =>
        {
            if(shootComponent.Shoot > 0 && shootAbility is Iability ability)
            {
                ability.Execute();
            }
        }
        ).WithoutBurst().Run();
    }
}
