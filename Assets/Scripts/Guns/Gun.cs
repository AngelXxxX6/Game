using UnityEngine;

public interface Gun 
{
  string Name { get; }
  float Damage { get; }
  int MaxAmmo { get; }  
  int ClupAmmo { get; }
  Sprite Icon { get; }
}
