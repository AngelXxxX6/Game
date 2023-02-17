using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
   
    private Vector2 _startPosition = Vector2.zero;
    private Vector2 _position = Vector2.zero;
    private RectTransform _rectTransform;
    private Image image;
    private float maxSize = 50f;
    public bool IsMove = false;
    public Vector2 Direction = Vector2.zero;
    void Start()
    {
        _rectTransform= GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(BaseEventData data)
    {
        PointerEventData pntr = (PointerEventData)data;
        _startPosition= pntr.position;
        image = GetComponent<Image>();
        IsMove = true;
    }
  
   public void OnDrag(BaseEventData data)
    {
        PointerEventData pntr = (PointerEventData)data;
        _position = pntr.position - _startPosition;
        float size = _position.magnitude;
        if (size > maxSize)
        {
            _position = _position / size * maxSize;
            
        }
        Direction = _position  / size;
       
        _rectTransform.localPosition = _position;
    }

    public void OnPointerUp(BaseEventData data) {
        _rectTransform.localPosition = Vector2.zero;
        IsMove = false;
      
        
    }
    
}
