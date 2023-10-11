using Unity.Entities;
using UnityEngine;

public class UnitSpawnTimeAuthoring : MonoBehaviour
{
    public float spawnInterval;
}

public class UnitSpawnTimeBaker : Baker<UnitSpawnTimeAuthoring>
{
    public override void Bake(UnitSpawnTimeAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new UnitSpawnTimeComponent
        {
            spawnInterval = authoring.spawnInterval,
        });
    }
}
