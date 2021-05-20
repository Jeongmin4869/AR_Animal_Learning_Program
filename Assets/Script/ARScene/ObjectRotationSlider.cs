using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRotationSlider : MonoBehaviour
{
    public GameObject ObjController;
    public Slider slider;
    public float zoomANT = 60f;


    // Update is called once per frame
    void Update()
    {
        ObjController.transform.rotation = Quaternion.Euler(0, zoomANT, 0);
    }

    public void sliderRotation()
    {
        zoomANT = slider.value;
    }

}
