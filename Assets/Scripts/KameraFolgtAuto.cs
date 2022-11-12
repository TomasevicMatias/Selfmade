using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class KameraFolgtAuto : MonoBehaviour
{
    //TODO
    //vielleicht eigene blender map
    //Handbremse
    //

    //Methoden
    public void LookAtTarget()
    {
        Vector3 lookDirection = objectToFollow.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, lookSpeed * Time.deltaTime);
    }

    public void MoveToTarget()
    {
        Vector3 targetPos =  objectToFollow.position +
                            objectToFollow.forward * offset.z +
                            objectToFollow.right * offset.x +
                            objectToFollow.up * offset.y;

        offset.Set(0, 2, -5);

        


        if (Input.GetKey(KeyCode.RightArrow))
        {
            offset.x = -4;
            offset.z = 0;                      
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            offset.x = 4;
            offset.z = 0;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            offset.z = 5;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            offset.z = -5;
        }





        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }

    private void FixedUpdate() //Fixedupdate editor , lateupdate build version! es wackelt dann dem entsprechend
    {
        


        LookAtTarget();
        MoveToTarget();
    }

    //Variablen
    public Transform objectToFollow;
    public Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 10;



}
