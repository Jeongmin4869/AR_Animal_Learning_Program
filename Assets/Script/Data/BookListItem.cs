using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookListItem : MonoBehaviour
{
    public Text AnimalText;
    public Text AnimalNum;
    public Text AnimalSubText;
    public Image AnimalImage;
    public Button Item_btn;
    public int id;
    public string spriteName;

    public void Init(int id, string animalSpriteName, string animalName, string animalsubText, int animalNum)
    {
        this.id = id;
        //this.iconMission.sprite = AssetManager.Instance.atlas.GetSprite(missionSpriteName);
        this.AnimalText.text = animalName;//string.Format("", missionName);
        this.AnimalNum.text = ""+animalNum;
        this.AnimalSubText.text = animalsubText;
        spriteName = string.Format("image/{0}", animalSpriteName);
        AnimalImage.sprite = Resources.Load<Sprite>(spriteName);
    }


}
