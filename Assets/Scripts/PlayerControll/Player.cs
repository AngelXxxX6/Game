using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AnimationClip _takeGunAnimation;
    [SerializeField] private Joystick _joy;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private AssetGun gun;
    private TMP_Text _energyText;
    private Transform _transform;
    private Rigidbody2D _rb;
    private Vector2 _direction;
    private float _speed = 5;
    private Camera camera;
    private MoveState _moveState = MoveState.walk;
    private Animator _animator;
    

    public float _health { get; private set; }
    public int _money { get; private set; }

    public float _energy { get; private set; } = 100;

    public float _commonArmor { get; private set; }
    
    public float _toxicArmor { get; private set; }

    public bool _haveGun { get; private set; }
    
    

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _energyText = GameObject.Find("EnergyValue").GetComponent<TMP_Text>();
      _transform= GetComponent<Transform>();
        _rb=GetComponent<Rigidbody2D>();
        camera = Camera.main;
        _haveGun = false;
        _health = 100;
        _joy = GameObject.FindObjectOfType<Joystick>();
    }
    private void OnEnable()
    {
        Events.DropGun += DropGun;
        Events.ChangeState += ChangeState;
        Events.Shoot += Shoot;
        Events.TakeDamageToPlayer+= TakeDamage;

    }
    private void OnDisable()
    {
        Events.DropGun -= DropGun;
        Events.ChangeState -= ChangeState;
        Events.Shoot -= Shoot;
        Events.TakeDamageToPlayer -= TakeDamage;
    }

    private void FixedUpdate()
    {
        
        if (_joy.IsMove)
        {
            
            _direction = _joy.Direction.normalized;
             float angle = MathF.Atan2(_direction.y,_direction.x) *Mathf.Rad2Deg;
        
            _rb.velocity = _direction * _speed;
            float rotateZ = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + 90);
            _animator.SetBool("move", true);
        }
        else
        {
            
            _rb.velocity = Vector2.zero;
            _animator.SetBool("move", false);
        }

        if (_moveState == MoveState.run)
        {
            _energy -= 1;
            if(_energy <=0)
            {
                _energy = 0;
                ChangeState(MoveState.walk);
            }
        }
        else
        {
            if (_energy < 100)
            {
                _energy += 1;
            }
        }
        _energyText.text = _energy.ToString();
        camera.transform.position = new Vector3(_transform.position.x, _transform.position.y, camera.transform.position.z);
        
    }

    
    private void ChangeState(MoveState moveState)
    {
        _moveState = moveState;
        if(_moveState == MoveState.walk)
        {
            _speed = 5;
        }
        else if(_moveState == MoveState.run)
        {
            _speed = 10;
        }
        else if(_moveState == MoveState.snick)
        {
            _speed = 1;
        }
    }

    private void TakeGun()
    {
      
            _animator.Play(_takeGunAnimation.name);
            Debug.Log("ФЫВ");
       
    }

    private void DropGun(string name)
    {
       
    }

    private void ChangeArmor(float value, string typeArmor)
    {
        switch(typeArmor)
        {
            case "common":_commonArmor += value;break;
            case "toxic": _toxicArmor += value;break;
        }
    }

    private void Shoot()
    {
        var a = Instantiate(_bullet,transform.position, Quaternion.identity);
       var b = a.GetComponent<Bullet>();
        b.TakeStats(gun.Damage, "player");
       var c = b.GetComponent<Rigidbody2D>();
        float rotateZ = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        a.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + 90);
        c.AddForce(_direction.normalized * 20f,ForceMode2D.Impulse);
    }

    private void TakeDamage(float damage, GameObject bullet)
    {
               
            Destroy(bullet);
            _health = _health - damage;
            if(_health <= 0)
            {
                
                Death();
            }
               
    }
    
    private void Death()
    {
        Debug.Log("Игрок");
        
    }
    public enum MoveState
    {
        walk,
        run,
        snick

    }

    
}
