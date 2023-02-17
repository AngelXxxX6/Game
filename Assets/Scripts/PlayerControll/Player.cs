using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text _energyText;
    private Transform _transform;
    private Rigidbody2D _rb;
    private Vector3 _direction;
    private float _speed = 5;
    private Camera camera;
    private MoveState _moveState = MoveState.walk;

    public int _health { get; private set; }
    public int _money { get; private set; }

    public float _energy { get; private set; } = 100;

    public float _commonArmor { get; private set; }
    
    public float _toxicArmor { get; private set; }

    
        

    private void Start()
    {
      _transform= GetComponent<Transform>();
        _rb=GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }
    private void OnEnable()
    {
        Events.DropGun += DropGun;
        Events.ChangeState += ChangeState;

    }
    private void OnDisable()
    {
        Events.DropGun -= DropGun;
        Events.ChangeState -= ChangeState;
    }
    private void FixedUpdate()
    {   

        _direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), _transform.position.z);
        _rb.velocity= _direction * _speed;
        if(_moveState == MoveState.run)
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
   
    public enum MoveState
    {
        walk,
        run,
        snick

    }


}
