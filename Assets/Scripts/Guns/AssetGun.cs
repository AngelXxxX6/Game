using UnityEngine;


[CreateAssetMenu(menuName = "Gun")]
public class AssetGun :  ScriptableObject,Gun
{
    public string Name => _name;

    public Sprite Icon => _uiIcon;

    public float Damage => _damage;

    public int MaxAmmo => _maxAmmo;

    public int ClupAmmo => _clupAmmo;

    [SerializeField] private string _name;
    [SerializeField] private Sprite _uiIcon;
    [SerializeField] private float _damage;
    [SerializeField] private int _maxAmmo;
    [SerializeField] private int _clupAmmo;

}

