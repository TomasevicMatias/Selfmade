using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_Ruecklicht : MonoBehaviour
{

    Light P2_RL;

    void Start()
    {
        P2_RL = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad5) || Input.GetKey(KeyCode.Keypad0))
        {
            P2_RL.enabled = true;
        }
        else
        {
            P2_RL.enabled = false;
        }
    }
}
