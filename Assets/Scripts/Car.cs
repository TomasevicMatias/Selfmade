using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    Rigidbody rigid;
    public Light LichtFR;
    public Light LichtFL;
    public Light LichtBR;
    public Light LichtBL;
    
void Start()
    {
        rigid = GetComponent<Rigidbody>();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LichtFR.enabled = !LichtFR.enabled;
            LichtFL.enabled = !LichtFL.enabled;
        }
    }

    public float GetSpeed()
    {
        return rigid.velocity.magnitude;
    }


}
