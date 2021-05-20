using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomInCamera : MonoBehaviour
{
    Camera cam;
    public Slider slider;
    public float zoomANT = 60f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.fieldOfView = zoomANT;
    }

    public void sliderZoom()
    {
        zoomANT = slider.value;
    }

}
