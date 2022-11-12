using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //Methoden
    public void GetInput()
    {
        horizonatlinput = Input.GetAxis("Horizontal");
        verticalinput = Input.GetAxis("Vertical");
    }

    private void Lenken()
    {
        steeringangle = maxSteerAngle * horizonatlinput;
        vornelinks.steerAngle = steeringangle;
        vornerechts.steerAngle = steeringangle;
    }
    
    private void Beschleunigen()
    {
        hintenrechts.motorTorque = verticalinput * motorForce;
        hintenlinks.motorTorque = verticalinput * motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(vornelinks, vornelinks2);
        UpdateWheelPose(vornerechts, vornerechts2);
        UpdateWheelPose(hintenlinks, hintenlinks2);
        UpdateWheelPose(hintenrechts, hintenrechts2);
    }

    private void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        Vector3 pos = transform.position;
        Quaternion quat = transform.rotation;

        collider.GetWorldPose(out pos, out quat);

        transform.position = pos;
        transform.rotation = quat;
    }

    private void Handbremse()
    {
        hintenrechts.motorTorque = 0;
        hintenlinks.motorTorque = 0;
    }

    private void FixedUpdate()
    {
        GetInput();
        if (Input.GetKey(KeyCode.Space))
        {
            Handbremse();
        }
        else
        {
            Beschleunigen();
        }
           
        Lenken();        
        UpdateWheelPoses();
    }   


    //Variablen
    private float horizonatlinput;
    private float verticalinput;
    private float steeringangle;

    public WheelCollider vornelinks, vornerechts;
    public WheelCollider hintenlinks, hintenrechts;
    public Transform vornelinks2, vornerechts2;
    public Transform hintenlinks2, hintenrechts2;
    public float maxSteerAngle = 30;
    public float motorForce = 50;




}
