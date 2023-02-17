using UnityEngine;

public class DroppedGun : MonoBehaviour
{
    [SerializeField] private string _name;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Events.OnTakeGun(_name, gameObject);

        }
    }
}
