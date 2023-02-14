using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    private Transform _transform;
    private Rigidbody2D _rb;
    private Vector3 _direction;
    private float _speed = 10;

    public int _health { get; private set; }
    public int _money { get; private set; }

    

    private void Start()
    {
      _transform= GetComponent<Transform>();
        _rb=GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        Events.DropGun += DropGun;
    }
    private void OnDisable()
    {
        Events.DropGun -= DropGun;
    }
    private void FixedUpdate()
    {
        _direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), _transform.position.z);
        _rb.velocity= _direction * _speed;
    }

    private void Update()
    {
        
    }
    
    private void DropGun(string name)
    {
       
    }
   
}
