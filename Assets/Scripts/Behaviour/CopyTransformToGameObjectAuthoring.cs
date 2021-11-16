using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class CopyTransformToGameObjectAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new CopyTransformToGameObject());
    }
}
