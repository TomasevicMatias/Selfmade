using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class SelfmadeController : MonoBehaviour
{
    //Räder
    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelRL;
    public WheelCollider WheelRR;
    public Transform WheelFLtrans;
    public Transform WheelFRtrans;
    public Transform WheelRLtrans;
    public Transform WheelRRtrans;

    //Handbremse
    private bool braked = false;
    private float maxBrakeTorque = 500;

    //Physik vom Auto
    private Rigidbody rb;
    public Transform centreofmass;
    private float maxTorque = 10000;

    //Movement
    int X;
    int Y;
    public int brakingspeed = 5;
    public int steering = 1;

    //Canvas
    public GameObject needle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centreofmass.transform.localPosition;
    }

    void FixedUpdate()
    {
        if (!braked)
        {
            WheelFL.brakeTorque = 0;
            WheelFR.brakeTorque = 0;
            WheelRL.brakeTorque = 0;
            WheelRR.brakeTorque = 0;
        }

        //Bewegt das auto
        WheelRR.motorTorque = maxTorque * X / 2;
        WheelRL.motorTorque = maxTorque * X / 2;

        //Rad ändert rotation (steer angle)
        WheelFL.steerAngle = 34 * Y;
        WheelFR.steerAngle = 34 * Y;
    }
    void Update()
    {
        UpDateNeedle();

        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            X = 1;
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {                       
            X = -1;           
        }
        

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Y = -1;
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            Y = 1;
        }

        if(Input.GetKeyUp(KeyCode.Keypad8) || Input.GetKeyUp(KeyCode.Keypad5))
        {
            X = 0;
        }

        if (Input.GetKeyUp(KeyCode.Keypad4) || Input.GetKeyUp(KeyCode.Keypad6))
        {
            Y = 0;
        }

        if(Input.GetKeyUp(KeyCode.Keypad8) && Input.GetKeyUp(KeyCode.Keypad5))
        {
            rb.drag = 1;
        }
        else
        {
            rb.drag = 1/100;
        }

        HandBrake();

        //Damit sich das Rad dreht
        WheelFLtrans.Rotate(WheelFL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        WheelFRtrans.Rotate(WheelFR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        WheelRLtrans.Rotate(WheelRL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        WheelRRtrans.Rotate(WheelRL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        
        
        //Dreht das Rad wieder zur Ursprungsposition wenn nicht gelenkt wird
        Vector3 temp = WheelFLtrans.localEulerAngles;
        Vector3 temp1 = WheelFRtrans.localEulerAngles;
        temp.y = WheelFL.steerAngle - (WheelFLtrans.localEulerAngles.z - 80);
        WheelFLtrans.localEulerAngles = temp;
        temp1.y = WheelFR.steerAngle - (WheelFRtrans.localEulerAngles.z - 80);
        WheelFRtrans.localEulerAngles = temp1;

    }
    void HandBrake()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            braked = true;
        }
        else
        {
            braked = false;
        }
        if (braked == true)
        {
            WheelRL.brakeTorque = maxBrakeTorque * 20;
            WheelRR.brakeTorque = maxBrakeTorque * 20;
            WheelRL.motorTorque = 0;
            WheelRR.motorTorque = 0;
        }        
    }
    public void UpDateNeedle()
    {
        needle.transform.eulerAngles = new Vector3(0, 0, Convert.ToInt32(217.5 - (rb.velocity.magnitude * 1.5)));
    }
}
