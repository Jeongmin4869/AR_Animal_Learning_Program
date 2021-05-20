using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkButton : MonoBehaviour
{
    public Animator[] animator;
    public int animalNum;
    private void Start()
    {
    
        animalNum = PlayerPrefs.GetInt("NowPickAnimal");
       // animator[animalNum] = GetComponent<Animator>();
    }
    public void onClickWalkButton()
    {
        if (animator[animalNum].gameObject.activeSelf)
        {
            animator[animalNum].SetInteger("AnimalState", 1);
        }
        else
        {
            Debug.Log("false");
        }
    }
}
