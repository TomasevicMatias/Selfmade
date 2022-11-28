using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCollider : MonoBehaviour
{
    public bool IsTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Car>())
        {
            IsTriggered = true;
            LapManager.instance.CheckLaps();           
        }
    }
}
