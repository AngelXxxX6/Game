
using UnityEngine;
public interface Mob
{
    string Name { get; }
    float Health { get; }

   AssetGun gun { get; }
    Sprite Icon { get; }
}
