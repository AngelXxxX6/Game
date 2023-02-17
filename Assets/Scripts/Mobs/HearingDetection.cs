using UnityEngine;

public class HearingDetection : MonoBehaviour
{
    
    private float radius = 0.4f;
    CircleCollider2D circle;

    private void Start()
    {
        circle= GetComponent<CircleCollider2D>();
        circle.radius = radius;
    }
    private void OnEnable()
    {
        Events.ChangeState += ChangeRadius;
    }
    private void OnDisable()
    {
        Events.ChangeState -= ChangeRadius;
    }
    private void ChangeRadius(Player.MoveState state)
    {
        if(state == Player.MoveState.walk)
        {
            radius = 0.4f;
        }
        else if(state == Player.MoveState.run) {

            radius = 0.6F;
        }
        else if(state == Player.MoveState.snick) {

            radius = 0.2F;
        }
        circle.radius = radius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            Events.OnVision(true);
        }

    }
    
}
