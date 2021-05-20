using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject HeartBtn;
    private int animal_Index;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Tiger")
        {
            HeartBtn.SetActive(true);
            animal_Index = 0;
        }
        else if (collider.tag == "Horse")
        {
            HeartBtn.SetActive(true);
            animal_Index = 1;
        }
        else if (collider.tag == "Elephant")
        {
            HeartBtn.SetActive(true);
            animal_Index = 2;
        }
        else if (collider.tag == "Zebra")
        {
            HeartBtn.SetActive(true);
            animal_Index = 3;
        }
        else if (collider.tag == "Rhinoceros")
        {
            HeartBtn.SetActive(true);
            animal_Index = 4;
        }
        else if (collider.tag == "Leopard")
        {
            HeartBtn.SetActive(true);
            animal_Index = 5;
        }
        else if (collider.tag == "IndianElephant")
        {
            HeartBtn.SetActive(true);
            animal_Index = 6;
        }
        PlayerPrefs.SetInt("NowPickAnimal", animal_Index);
        PlayerPrefs.Save();

    }
    
    private void OnTriggerExit(Collider collider)
    {
            HeartBtn.SetActive(false);
    }
}
