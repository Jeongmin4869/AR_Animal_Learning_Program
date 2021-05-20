using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSetting : MonoBehaviour
{

    public GameObject[] animal;
    public Transform objPosition;

    // Start is called before the first frame update
    void Start()
    {
        setAnimal();

    }

    public void setAnimal()
    {
        if (PlayerPrefs.HasKey("NowPickAnimal"))
        {
            //지금 픽한 애니멀 확인! 세팅
            int index = PlayerPrefs.GetInt("NowPickAnimal");
            //Instantiate(animal[index], objPosition.position, objPosition.rotation);


            var tmpObject = GameObject.Instantiate(animal[index], new Vector3(0,-1,0), Quaternion.identity);    // 오브젝트 생성
            tmpObject.transform.parent = objPosition;
            objPosition.rotation = Quaternion.Euler(0, 180, 0);
            //objPosition.position = new Vector3(0, -1, 0);
            objPosition.localScale = new Vector3(0.7f, 0.7f, 0.7f);
 
        }
    }

}
