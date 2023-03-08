using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_Ruecklicht : MonoBehaviour
{

    Light P1_RL;

    void Start()
    {
        P1_RL = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Space))
        {
            P1_RL.enabled = true;
        }
        else
        {
            P1_RL.enabled = false;
        }
    }
}
