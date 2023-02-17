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

    [SerializeField] private float _health;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;
    [SerializeField] private AssetGun _gun;

}
