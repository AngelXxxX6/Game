using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class MobPrefab : MonoBehaviour, Mob
{
   [SerializeField] private AssetMob _assetMob;
    private Transform _player;
    
    private bool _isPlayerInVision = false;
    private float _health;
    private NavMeshAgent agent;
    
    string Mob.Name => _assetMob.Name;

    float Mob.Health => _assetMob.Health;

    AssetGun Mob.gun => _assetMob.gun;

    Sprite Mob.Icon => _assetMob.Icon;

    float Mob.speed=> _assetMob.speed;

    float Mob.distanceWalk => _assetMob.distanceWalk;

    float Mob.distanceRun => _assetMob.distanceRun;

    float Mob.distanceSnick => _assetMob.distanceSnick;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis= false;
        agent.speed = _assetMob.speed;
        _health = _assetMob.Health;
    }

    private void OnEnable()
    {
        Events.InVision += ChangeVision;
        Events.TakeDamageToMob += TakeDamage;
    }
    private void OnDisable()
    {
        Events.InVision -= ChangeVision;
        Events.TakeDamageToMob -= TakeDamage;
    }
    private void ChangeVision(bool state)
    {
        _isPlayerInVision = state;
    }
    private void TakeDamage(float damage,GameObject bullet)
    {
        
         _health -=damage;
           Destroy(bullet);
            
            if (_health <= 0)
            {
                
                Death();
            }
        
    }

    private void Death()
    {
        Debug.Log("Умер");
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        if (_isPlayerInVision)
        {
            agent.SetDestination(_player.position);
            float rotateZ = Mathf.Atan2(_player.position.y, _player.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + 90);
        }
       
        
    }

    
}
