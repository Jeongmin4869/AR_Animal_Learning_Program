 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookMenu : MonoBehaviour
{
    public GameObject BookMenuView;
    public Text subText;

    void OnEnable()
    {
        subText.text = string.Format("7 동물중 {0} 동물을 찾았습니다.", TestUGUI.gameInfo.missionInfos.Count);
    }


    //string.Format
    public void clickCancelBtn()
    {
        BookMenuView.SetActive(false);
        Time.timeScale = 1;
    }

}
