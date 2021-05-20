using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleButton : MonoBehaviour
{
    public Animator[] animator;
    public int animalNum;
    private void Start()
    {
        animalNum = PlayerPrefs.GetInt("NowPickAnimal");
        //animator[animalNum] = GetComponent<Animator>();
    }
    public void onClickIdleButton()
    {
        animator[animalNum].SetInteger("AnimalState", 0);
    }
}
