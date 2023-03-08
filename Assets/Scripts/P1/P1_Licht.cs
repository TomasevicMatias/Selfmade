using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_Licht : MonoBehaviour
{

    Light P1_Lichter;

    // Start is called before the first frame update
    void Start()
    {
        P1_Lichter = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            P1_Lichter.enabled = !P1_Lichter.enabled;
        }
    }
}
