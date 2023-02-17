using System;
using UnityEngine;


public class Events : MonoBehaviour
{
    public static Action<string,GameObject> TakeGun;
    public static Action<string> DropGun;
    public static Action<Player.MoveState> ChangeState;
    public static void OnTakeGun(string name,GameObject gameObject)
    {
        if(TakeGun != null)
        {
            TakeGun.Invoke(name,gameObject);
        }
    }
    public static void OnDropGun(string name)
    {
        if (DropGun != null)
        {
            DropGun.Invoke(name);
        }
    }
    public static void OnChangeState(Player.MoveState moveState)
    {
        if (ChangeState != null)
        {
            ChangeState.Invoke(moveState);
        }
    }

}
