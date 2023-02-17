using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobPrefab : MonoBehaviour, Mob
{
   [SerializeField] private AssetMob _assetMob;
    [SerializeField] private Player _player;
    private Rigidbody2D _rb;
    string Mob.Name => _assetMob.Name;

    float Mob.Health => _assetMob.Health;

    AssetGun Mob.gun => _assetMob.gun;

    Sprite Mob.Icon => _assetMob.Icon;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 vectorToPlayer = _player.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector2.right, vectorToPlayer);
        GetComponent<Rigidbody2D>().velocity = transform.right;
    }
}
