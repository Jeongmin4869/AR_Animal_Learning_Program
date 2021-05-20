using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // 키보드, 마우스, 터치를 이벤트로 오브젝트에 보낼 수 있는 기능을 지원
using UnityEngine.UIElements;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    //private RectTransform lever;
    //private RectTransform rectTransform;

    public Transform cameraArm;
    public  Vector2 FirstTouchPoint;

    [SerializeField,Range(10,150)]
    //private float leverRange;

    private Vector2 inputDirection;
    public float speed=1;
    //private bool isInput;

    public enum JoystickType { Move, Rotate}
    public JoystickType joystickType;

    private void Awake()
    {
        //rectTransform = GetComponent<RectTransform>();
    }

    


    public void OnBeginDrag(PointerEventData eventData)
    {
        FirstTouchPoint = eventData.position;
        ControlJoystickLever(eventData);
        //isInput = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        LookAround(inputDirection);
        FirstTouchPoint = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        FirstTouchPoint = Vector3.zero;
        //lever.anchoredPosition = Vector2.zero;
        //isInput = false;
    }

    public void ControlJoystickLever(PointerEventData eventData)
    {
        var inputPos = (Vector2)eventData.position - FirstTouchPoint;//rectTransform.anchoredPosition;
        var inputVecter = inputPos.magnitude;// < leverRange ? inputPos : inputPos.normalized * leverRange;
        //lever.anchoredPosition = inputPos;
        inputDirection = inputPos.normalized * -1; // / leverRange; 방향벡터
        //speed = inputPos.normalized * 2;
    }

    private void InputControlVector()
    {
        //캐릭터에게 입력벡터를 전달

        switch (joystickType)
        {
            case JoystickType.Move:
                break;
            case JoystickType.Rotate:
                LookAround(inputDirection);
                break;
        }

    }

    private void LookAround(Vector3 inputDirection)
    {
        Vector2 mouseDelta = inputDirection;// new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        Vector3 camAngle = cameraArm.rotation.eulerAngles;

        float x = camAngle.x - mouseDelta.y;

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }
        cameraArm.rotation = Quaternion.Euler(x, (camAngle.y + mouseDelta.x), camAngle.z);
        //cameraArm.transform.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //LookAround(inputDirection);

        /*
        if (isInput)
        {
            InputControlVector();
        } 
        */
    }
}
