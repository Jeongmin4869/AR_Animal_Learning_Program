using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    [SerializeField] private RectTransform rect_Background;
    [SerializeField] private RectTransform rect_Joystick;

    private float radius;

    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;

    private bool isTouch = false;
    private Vector3 movePosition;

    //private Vector2 touchPosition;
    //private float swipeResistance = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        radius = rect_Background.rect.width * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch)
        {

         
            //이상한 곳으로 좌표 이동해서 space.world해봤음 -> 정상적
            player.transform.Translate(player.transform.forward * movePosition.z,Space.World);
            player.transform.Translate(player.transform.right * movePosition.x, Space.World);


            
            //player.position += movePosition;

        }


        /*
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            touchPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)) // release
        {
            float swipeForce = touchPosition.x - Input.mousePosition.x;
            if(Mathf.Abs(swipeForce) > swipeResistance)
            {
                if (swipeForce < 0)
                    SlideCamera(true);
                else
                    SlideCamera(false);
            }
        }*/
    }



    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)rect_Background.position;

        //backgournd넘지않게 가둔다
        value = Vector2.ClampMagnitude(value, radius);
        //if (1, 4) value = -3~5

        rect_Joystick.localPosition = value; // 부모객체의 기준으로 좌표

        float distance = Vector2.Distance(rect_Background.position, rect_Joystick.position)/radius;

        value = value.normalized; // value의 속도값은 빠지고 방향값만 남는다.
        movePosition = new Vector3(value.x * moveSpeed * Time.deltaTime * distance,
            0f,
            value.y * moveSpeed * Time.deltaTime * distance);
        //movePosition.front

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        rect_Joystick.localPosition = Vector3.zero;//조이스틱 원위치로
        movePosition = Vector3.zero;
    }

}
