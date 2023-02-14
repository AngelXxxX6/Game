using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedGun : MonoBehaviour
{
    [SerializeField] private string _name;
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Events.OnTakeGun(_name);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
