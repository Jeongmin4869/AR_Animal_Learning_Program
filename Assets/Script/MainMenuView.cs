using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    public Button GrayView;
    public GameObject MainManuView;
    public GameObject player;
    

    public void Go_First_Pos()
    {
        Time.timeScale = 1;
        player.transform.position = new Vector3(0, 1, 0);
        player.transform.eulerAngles = new Vector3(0, 0, 0);
        MainManuView.SetActive(false);
    }

    public void clearDataAndClose()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void eixtGame()
    {
        Application.Quit();
    }

    public void onClickGrayView()
    {
        MainManuView.SetActive(false);
        Time.timeScale = 1;
    }

}
