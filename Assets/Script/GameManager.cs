using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerPosition();
    }

    // Update is called once per frame
    void OnApplicationQuit()
    {
        //게임 종료 시 기본 위치의 포지션으로 저장
        PlayerPrefs.SetFloat("PlayerX", 0);
        PlayerPrefs.SetFloat("PlayerZ",0);
        PlayerPrefs.SetFloat("PlayerAngles", 0);
        PlayerPrefs.Save();
    }

    public void LoadPlayerPosition()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerZ");
        float p_angles = PlayerPrefs.GetFloat("PlayerAngles");

        player.transform.position = new Vector3(x, 1, y);
        player.transform.eulerAngles = new Vector3(0, p_angles, 0); 
    }

}
