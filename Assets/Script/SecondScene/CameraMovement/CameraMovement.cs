using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;

    private Vector3 previousPosition;

    public float speed = 5;
    public float minFov = 35f;
    public float maxFov = 100f;
    public float sensitivity = 17f;

    public bool UiClick = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsPointerOverUIObject(Input.mousePosition))//클릭한것이 UI일경우
            {
                UiClick = true;
            }
            else
                UiClick = false;
        }


        if (Input.GetMouseButton(0))
        {
            if (!UiClick) //클릭한것이 UI가 아닐경우
            {

                cam.transform.position = target.position; //new Vector3(); 

                cam.transform.Rotate(new Vector3(-1, 0, 0), Input.GetAxis("Mouse Y") * speed);
                cam.transform.Rotate(new Vector3(0, -1, 0), Input.GetAxis("Mouse X") * -speed, Space.World);

                cam.transform.Translate(new Vector3(0, 0, -2.5f));

            }
        }
      
    }

    public bool IsPointerOverUIObject(Vector2 touchPos)
    {
        PointerEventData eventDataCurrentPosition
            = new PointerEventData(EventSystem.current);

        eventDataCurrentPosition.position = touchPos;

        List<RaycastResult> results = new List<RaycastResult>();


        EventSystem.current
        .RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }

}
