using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerRotateController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Camera cam;
    public float Speed = 5;

    private float p_y;
    public bool UiClick = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
            if (!UiClick)
            {
                p_y = Input.GetAxis("Mouse Y");

                /*if (p_y < 180f)
                {
                    p_y = Mathf.Clamp(p_y, -1, 70f);
                }
                else
                {
                    p_y = Mathf.Clamp(p_y, 335f, 361f);
                }*/


                //플레이어 하늘날아서 플레이어, 카메라 객체 따로 회전걸음.
                //player.transform.eulerAngles += Speed * new Vector3(x: 0, y: -Input.GetAxis("Mouse X"), z: 0);

                //-80 ~ 80

                float x = cam.transform.eulerAngles.x;
                float y = cam.transform.eulerAngles.y;
                x += p_y * Speed;
                float n = -Input.GetAxis("Mouse X") * Speed;
                y += n;
                player.transform.rotation = Quaternion.Euler(0, y, 0);
                //cam.transform.rotation = Quaternion.Euler(x, 0, 0);
                //player.transform.eulerAngles += Speed * new Vector3(x: 0, y: -Input.GetAxis("Mouse X"), z: 0);
                //cam.transform.eulerAngles += Speed * new Vector3(x: p_y, y: 0, z: 0);
                /*
                if (cam.transform.rotation.eulerAngles.x > 80)
                {
                    //cam.transform.eulerAngles = new Vector3(x: 80, y: 0, z: 0);
                    if (cam.transform.rotation.eulerAngles.x <270 )//&& cam.transform.rotation.eulerAngles.x!=360)
                        cam.transform.eulerAngles = new Vector3(x: -80, y: 0, z: 0);
                    else
                    {
                        cam.transform.eulerAngles = new Vector3(x: 80, y: 0, z: 0);
                    }
                }
               */
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
