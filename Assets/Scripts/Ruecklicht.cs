using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruecklicht : MonoBehaviour
{

    Light light;

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }
    }
}
