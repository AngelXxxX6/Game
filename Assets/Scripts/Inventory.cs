using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<AssetGun> Guns;
    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] private Transform content;
    
    private void OnEnable()
    {
        Events.TakeGun += AddInInventory;
        Events.DropGun += DeleteFromInventory;
    }
    private void OnDisable()
    {
        Events.TakeGun -= AddInInventory;
        Events.DropGun -= DeleteFromInventory;
    }
    private void Render(List<AssetGun> Guns)
    {
        foreach(Transform child in content) {

            Destroy(child.gameObject);
        }
        Guns.ForEach(gun =>
        {
            var cell = Instantiate(_inventoryCellTemplate, content);
            cell.Render(gun);
        });
    }

    private void AddInInventory(string name)
    {
        AssetGun gun = Resources.Load($"Guns/{name}",typeof(AssetGun)) as AssetGun;
        Guns.Add(gun);
        Render(Guns);
    }
    private void DeleteFromInventory(string name)
    {
        Debug.Log(name);
        Guns.Remove(Guns.Find(gun=> gun.name == name));
        Render(Guns);
    }
}
