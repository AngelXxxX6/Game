using UnityEngine;
using UnityEngine.UI;

class InventoryCell : MonoBehaviour
{
    [SerializeField] private Text _nameField;
    [SerializeField] private Image _icon;

       

    public void Render(Gun gun)
    {
        _nameField.text = gun.Name;
        _icon.sprite = gun.Icon;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Events.OnDropGun(_nameField.text);
        }
    }

}

