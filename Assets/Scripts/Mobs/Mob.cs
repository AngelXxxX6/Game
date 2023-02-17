
using UnityEngine;
public interface Mob
{
    string Name { get; }
    float Health { get; }

    float speed { get; }

    AssetGun gun { get; }
    Sprite Icon { get; }

    float distanceWalk { get; }
    float distanceRun { get; }

    float distanceSnick { get; }

    
}
