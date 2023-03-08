using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_Licht : MonoBehaviour
{

    Light P2_Lichter;

    // Start is called before the first frame update
    void Start()
    {
        P2_Lichter = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            P2_Lichter.enabled = !P2_Lichter.enabled;
        }
    }
}
