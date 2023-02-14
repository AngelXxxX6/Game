using System;
using UnityEngine;


public class Events : MonoBehaviour
{
    public static Action<string> TakeGun;
    public static Action<string> DropGun;
    public static void OnTakeGun(string name)
    {
        if(TakeGun != null)
        {
            TakeGun.Invoke(name);
        }
    }
    public static void OnDropGun(string name)
    {
        if (DropGun != null)
        {
            DropGun.Invoke(name);
        }
    }
}
