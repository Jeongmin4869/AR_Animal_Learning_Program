using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubText : MonoBehaviour
{
    float time = 0.0f;

    // Update is called once per frame 
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 5)
        {
            Destroy(gameObject);
        }
    }
}
