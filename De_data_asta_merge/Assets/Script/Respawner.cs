using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public float threshhold;
    void FixedUpdate()
    {
        if(transform.position.y < threshhold)
        {
            transform.position = new Vector3(0f, 0.5f, 0f);
        }
    }
}
