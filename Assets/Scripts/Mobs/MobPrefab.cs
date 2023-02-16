using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobPrefab : MonoBehaviour, Mob
{
   [SerializeField] private AssetMob assetMob;
    string Mob.Name => assetMob.Name;

    float Mob.Health => assetMob.Health;

    AssetGun Mob.gun => assetMob.gun;

    Sprite Mob.Icon => assetMob.Icon;
}
