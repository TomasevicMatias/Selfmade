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


    [SerializeField] private Car car;


    // Start is called before the first frame update
    void Start()
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
            txtBestTime.text = "Best Time: " + BestTime.ToString("0.00") + "s";
        }
    }
}
