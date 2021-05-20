using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public GameObject MainManuView;

    public void onClickMenuBtn()
    {
        MainManuView.SetActive(true);
        Time.timeScale = 0;
    }
}
