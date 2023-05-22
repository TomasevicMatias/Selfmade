using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerTest : MonoBehaviour
{
    private float y;
    //vehicle control speed parameters
    private float speedOne = 0f; //Vehicle real-time speed
    private float speedMax = 120f; //The maximum speed of the vehicle
    private float speedMin = -20f; //The minimum speed of the vehicle (the maximum speed of reversing)
    private float speedUpA = 2f; //Vehicle acceleration acceleration (A key control)
    private float speedDownS = 4f; //Vehicle deceleration acceleration (S key control)
    private float speedTend = 0.5f; //Acceleration when no operation real-time speed tends to 0
    private float speedBack = 1f; //Vehicle reversing acceleration
                                  // Update is called once per frame
    void Update()
    {
        //mouse hide
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        //Press the W key and the speed does not reach the maximum, then the speed increases
        if (Input.GetKey(KeyCode.W) && speedOne < speedMax)
        {
            speedOne = speedOne + Time.deltaTime * speedUpA;
        }
        //Press the S key and the speed does not reach zero, then the speed is reduced
        if (Input.GetKey(KeyCode.S) && speedOne > 0f)
        {
            speedOne = speedOne - Time.deltaTime * speedDownS;
        }
        // No speed operation is performed and the speed is greater than the minimum speed, then the slow operation
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && speedOne > 0f)
        {
            speedOne = speedOne - Time.deltaTime * speedTend;
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && speedOne < 0f)
        {
            speedOne = speedOne + Time.deltaTime * speedTend;
        }

        //When the S key is pressed and the speed does not reach the maximum reversing speed, and the vehicle is in a state where the vehicle can be reversed, the vehicle reverses
        if (Input.GetKey(KeyCode.S) && speedOne > speedMin && speedOne <= 0)
        {
            speedOne = speedOne - Time.deltaTime * speedBack;
        }

        /// press space, the car stops
        if (Input.GetKey(KeyCode.Space) && speedOne != 0)
        {
            speedOne = Mathf.Lerp(speedOne, 0, 0.4f);
            if (speedOne < 5) speedOne = 0;
        }
        transform.Translate(Vector3.forward * speedOne * Time.deltaTime);
        //Use A and D to control the left and right rotation of the object
        //if (speedOne > 1f || speedOne < -1f)
        //{
        //    y = Input.GetAxis("Horizontal") * 60f * Time.deltaTime;
        //    transform.Rotate(0, y, 0);
        //}

        /* if (transform.eulerAngles.z != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, t 
            ransform.eulerAngles.y, 0);
        }*/
    }
}
