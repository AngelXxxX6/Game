
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _damage;
    private string _owner;

    public void TakeStats(float damage, string owner)
    {
        _damage= damage;
        _owner= owner;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Mob") &&  _owner == "player")
        {
            Events.OnTakeDamageToMob(_damage, gameObject);
        }
        else if (collision.gameObject.CompareTag("Player") && _owner == "mob")
        {
            Events.OnTakeDamageToPlayer(_damage, gameObject);
        }
        else if(collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }

    }

  
}
