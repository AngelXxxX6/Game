using System;
using UnityEngine;


public class Events : MonoBehaviour
{
    public static Action<string,GameObject> TakeGun;
    public static Action<string> DropGun;
    public static Action<Player.MoveState> ChangeState;
    public static Action<bool> InVision;
    public static Action<float,GameObject> TakeDamageToMob;
    public static Action<float, GameObject> TakeDamageToPlayer;
    public static Action Shoot;
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
    public static void OnVision(bool state)
    {
        if (InVision != null)
        {
            InVision.Invoke(state);
        }
    }

    public static void OnTakeDamageToMob( float damage,GameObject bullet)
    {
        if (TakeDamageToMob
            != null)
        {
            TakeDamageToMob.Invoke(damage,bullet);
        }
    }
    public static void OnTakeDamageToPlayer(float damage, GameObject bullet)
    {
        if (TakeDamageToPlayer
            != null)
        {
            TakeDamageToPlayer.Invoke(damage, bullet);
        }
    }
    public static void OnShoot()
    {
        if(Shoot !=null)
        {
            Shoot.Invoke();
        }
    }
    
}
