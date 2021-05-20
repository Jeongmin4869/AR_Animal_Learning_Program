using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInfo
{
    public int id;
    public bool checkAnimal;

    public MissionInfo(int id, bool check)
    {
        this.id = id;
        checkAnimal = check;
    }
}
