using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Mob")]
public class AssetMob : ScriptableObject, Mob
{
    public string Name => _name;

    public float Health => _health;

    public Sprite Icon => _icon;

    public AssetGun gun => _gun;

    public float speed => _speed;

    public float distanceWalk => _distanceWalk;

    public float distanceRun => _distanceRun;

    public float distanceSnick => _distanceSnick;

    string Mob.Name => throw new System.NotImplementedException();

    float Mob.Health => throw new System.NotImplementedException();

    float Mob.speed => throw new System.NotImplementedException();

    AssetGun Mob.gun => throw new System.NotImplementedException();

    Sprite Mob.Icon => throw new System.NotImplementedException();

    float Mob.distanceWalk => throw new System.NotImplementedException();

    float Mob.distanceRun => throw new System.NotImplementedException();

    float Mob.distanceSnick => throw new System.NotImplementedException();

    [SerializeField] private float _health;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;
    [SerializeField] private AssetGun _gun;
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceWalk;
    [SerializeField] private float _distanceRun;
    [SerializeField] private float _distanceSnick;

   
}
