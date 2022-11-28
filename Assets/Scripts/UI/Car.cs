using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    Rigidbody rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();        
    }

    public float GetSpeed()
    {
        return rigid.velocity.magnitude;
    }


}
