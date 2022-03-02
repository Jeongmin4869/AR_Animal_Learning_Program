using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using Newtonsoft.Json;

public class TestUGUI : MonoBehaviour
{
    public GameObject ObView;
    public BookListItem listItemPrefabs;
    public RectTransform contents;
    public static GameInfo gameInfo;
    private List<BookListItem> bookListItems = new List<BookListItem>();
    // Start is called before the first frame update
    void Start()
    {
        //데이터 로드
        DataManager.GetInstance().LoadData<BookData>("Data/book_data");
        testUGUISetting();
    }

    public void testUGUISetting() {

        //데이터 삭제
        //PlayerPrefs.DeleteAll();

        var json = PlayerPrefs.GetString("game_info");

        if (string.IsNullOrEmpty(json)) // 저장된 파일이 없을경우 True반환
        {
            TestUGUI.gameInfo = new GameInfo();
            var gameInfoJson = JsonConvert.SerializeObject(TestUGUI.gameInfo);//json을 storing형태로 저장.
            PlayerPrefs.SetString("game_info", gameInfoJson);
        }
        else
        {
            Debug.LogFormat("{0}", json);
            TestUGUI.gameInfo = JsonConvert.DeserializeObject<GameInfo>(json);

        }


        DeleteChilds();
        bookListItems.Clear();
        for (int i = 0; i < 7; i++)
        {   
            var bookData = DataManager.GetInstance().GetData<BookData>(i);
            var foundMission = TestUGUI.gameInfo.missionInfos.Find(x => x.id == bookData.animal_num-1);

            if (foundMission != null)
            {
                if (foundMission.checkAnimal)
                {
                    Debug.Log("조건만족");
                    var listItem = this.CreateListItem();
                    bookListItems.Add(listItem);
                    listItem.Item_btn.onClick.AddListener(() =>
                    {
                        this.Click_List_Item(listItem.id);
                    });
                    //var MissionName = string.Format(missionData.mission_name, missionData.goal_val.ToString("#,###"));
                    listItem.Init(bookData.id,bookData.sprite_name, bookData.animal_name, bookData.sub_text, bookData.animal_num);
                }
            }
        }
    }


    private void Click_List_Item(int id) // 클릭이벤트
    {
        var bookData = DataManager.GetInstance().GetData<BookData>(id);
        int animal_num = bookData.animal_num - 1;
        PlayerPrefs.SetInt("NowPickAnimal", animal_num);
        PlayerPrefs.Save();
        ObView.SetActive(true);
    }



    // Update is called once per frame
    private BookListItem CreateListItem()
    {
        var listItemGo = Instantiate(this.listItemPrefabs);
        listItemGo.transform.SetParent(contents, false);
        return listItemGo.GetComponent<BookListItem>();
    }

    public void DeleteChilds()
    {
        Transform allChildren = contents.GetComponentInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            // 자기 자신의 경우엔 무시 
            // (게임오브젝트명이 다 다르다고 가정했을 때 통하는 코드)
            if (child.name == transform.name)
                return;
            Destroy(child.gameObject);
        }
    }

}
