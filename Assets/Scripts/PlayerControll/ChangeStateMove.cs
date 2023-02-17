using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStateMove : MonoBehaviour
{
    [SerializeField] private Player.MoveState moveState;
    private bool _isDown = false;
    void Start()
    {
        
    }

    private void OnMouseDrag()
    {
        if(!_isDown)
        {
            _isDown = true;
             Events.OnChangeState(moveState);
        }
    }

    private void OnMouseUp()
    {
        Events.OnChangeState(Player.MoveState.walk);
        _isDown = false;
        
    }
    void Update()
    {
        
    }
}
