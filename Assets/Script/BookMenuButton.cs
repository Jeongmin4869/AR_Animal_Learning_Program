using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookMenuButton : MonoBehaviour
{

    public GameObject BookMenuView;
    // Start is called before the first frame update
    public void clickBookBtn()
    {
        BookMenuView.SetActive(true);
        Time.timeScale = 0;
        GameObject.Find("TestUGUI").GetComponent<TestUGUI>().testUGUISetting();
    }
}
