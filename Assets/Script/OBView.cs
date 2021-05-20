using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json;

public class OBView : MonoBehaviour
{

    public GameObject ObView;
    public GameObject player;
    public Text animal_nameB;
    public Text animal_nameW;
    public Text sub_text;
    public Image AnimalImage; // 나중에 쓸 예정!

    int animalNum;


    void OnEnable()
    {
        Load_And_Set_AnimalData();
        saveAnimalNum(animalNum);
    }

    public void OnClickCancleBtn()
    {
        ObView.SetActive(false);
        Time.timeScale = 1;
    }

    public void onClickShowObjInUnityBtn()
    {
        SavePosition();
        SceneManager.LoadScene("SecondScene");
        Time.timeScale = 1;
    }

    public void onClickShowObjInARBtn()
    {
        SavePosition();
        SceneManager.LoadScene("ARScene");
        Time.timeScale = 1;
    }
    public void Load_And_Set_AnimalData()
    {
        if (PlayerPrefs.HasKey("NowPickAnimal"))
        {
            animalNum = PlayerPrefs.GetInt("NowPickAnimal");
            var bookData = DataManager.GetInstance().GetData<BookData>(animalNum);
            animal_nameB.text =  bookData.animal_name;
            animal_nameW.text = bookData.animal_name;
            sub_text.text = bookData.sub_text;
            AnimalImage.sprite = Resources.Load<Sprite>(string.Format("image/{0}", bookData.sprite_name));
        }
    
    }

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
        PlayerPrefs.SetFloat("PlayerAngles", player.transform.eulerAngles.y);
        PlayerPrefs.Save();
    }


    public void saveAnimalNum(int animalNum)
    {
        var json = PlayerPrefs.GetString("game_info");//파일 이미 만들어져 있기 때문에 null처리안함
        TestUGUI.gameInfo = JsonConvert.DeserializeObject<GameInfo>(json);
        var foundMissionInfo = TestUGUI.gameInfo.missionInfos.Find(x => x.id == animalNum);
        if (foundMissionInfo == null)
        {
            TestUGUI.gameInfo.missionInfos.Add(new MissionInfo(animalNum, true));//없을경우 새로 만들어 넣는다.
            var gameInfoJson = JsonConvert.SerializeObject(TestUGUI.gameInfo);//json을 storing형태로 저장.
            PlayerPrefs.SetString("game_info", gameInfoJson);
            PlayerPrefs.Save();
        }
    }


}
