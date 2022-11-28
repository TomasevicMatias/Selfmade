using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapUI : MonoBehaviour
{
    //Text
    public Text txtSpeed;
    public Text txtTime;
    public Text txtBestTime;
    public Text [] Checkpoint = new Text[4] ;
    public void CheckpointCheck(int CheckpointNumber, string LapTime)
    {
        Checkpoint[CheckpointNumber].text = LapTime;
    }

    [SerializeField] private Car car;
    public void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        float speed = car.GetSpeed();
        txtSpeed.text = "Speed: " + (speed*4).ToString("0.00") + "km/h";

        float laptime = LapManager.instance.GetLapTime();
        txtTime.text = "Time: " + laptime.ToString("0.00") + "s";        
               
        float BestTime = LapManager.instance.BestTime;                             
        if (BestTime != float.MaxValue)
        {
            txtBestTime.text = BestTime.ToString("0.00") + "s";
        }
    }
    
}
