using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObButton : MonoBehaviour
{
    public GameObject ObView;


    public void OnClickObBtn()
    {
        ObView.SetActive(true);
        Time.timeScale = 0;
    }

}
