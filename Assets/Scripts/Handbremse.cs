using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handbremse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Rigidbody auto;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            auto.drag *= 100;
        }
        else
        {
            auto.drag /= 100;
        }
    }
}
