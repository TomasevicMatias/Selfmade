using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapManager : MonoBehaviour
{
    public static LapManager instance;
    float laptime = 0;
    float bestTime = float.MaxValue;

    public float BestTime
    {
        get { return bestTime; }
    }

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        laptime += Time.deltaTime;
    }

    void SetNewBestTime()
    {
        if (laptime < BestTime)
        {
            bestTime = laptime;
        }
        laptime = 0;
    }

    public void CheckLaps()
    {
        LapCollider[] laps = GameObject.FindObjectsOfType<LapCollider>();

        foreach (LapCollider lap in laps)
        {
            if (!lap.IsTriggered)
            {
                return;
            }
        }

        SetNewBestTime();

        foreach (LapCollider lap in laps)
        {
            if (lap.IsTriggered)
            {
                lap.IsTriggered = false;
            }
        }


    }

    public float GetLapTime()
    {
        return laptime;
    }


}
