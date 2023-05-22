using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class TrackCheckpoints : MonoBehaviour {

    //Canvas Objects
    public Text txtLapCountP1;
    public Text txtCheckpointP1;
    public Text txtLapCountP2;
    public Text txtCheckpointP2;
    public Text txtWinner;
    private int lapcountP1 = 1;
    private int lapcountP2 = 1;
    public int Laps = 2;

    

    public event EventHandler OnPlayerCorrectCheckpoint;
    public event EventHandler OnPlayerWrongCheckpoint;

    [SerializeField] private List<Transform> carTransformList;

    private List<CheckpointSingle> checkpointSingleList;
    private List<int> nextCheckpointSingleIndexList;

    private void Awake() {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform) 
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();

            checkpointSingle.SetTrackCheckpoints(this);

            checkpointSingleList.Add(checkpointSingle);
        }

        nextCheckpointSingleIndexList = new List<int>();
        foreach (Transform carTransform in carTransformList) 
        {
            nextCheckpointSingleIndexList.Add(0);
        }
    }

    public void CarThroughCheckpoint(CheckpointSingle checkpointSingle, Transform carTransform) 
    {
        int nextCheckpointSingleIndex = nextCheckpointSingleIndexList[carTransformList.IndexOf(carTransform)];
        if (checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex) 
        {
            // Correct checkpoint
            Debug.Log("Correct");
            CheckpointSingle correctCheckpointSingle = checkpointSingleList[nextCheckpointSingleIndex];
            correctCheckpointSingle.Hide();

            nextCheckpointSingleIndexList[carTransformList.IndexOf(carTransform)] = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
            OnPlayerCorrectCheckpoint?.Invoke(this, EventArgs.Empty);

            if(carTransform == carTransformList.ElementAt(0))
            {
                txtCheckpointP1.text = Convert.ToString("CP: " + (nextCheckpointSingleIndex+1)) + "/15";
                if ((nextCheckpointSingleIndex + 1) == 15)
                {
                    lapcountP1++;
                    if (lapcountP1 == Laps + 1 && lapcountP2 != Laps + 1 && lapcountP2 < Laps + 1)
                    {
                        txtWinner.enabled = true;
                        txtWinner.text = Convert.ToString("Winner\r\nPlayer1");
                    }
                    else
                    {
                        txtLapCountP1.text = Convert.ToString("Lap: " + lapcountP1 + "/" + Laps);
                    }
                }
            }
            
            if (carTransform == carTransformList.ElementAt(1))
            {
                txtCheckpointP2.text = Convert.ToString("CP: " + (nextCheckpointSingleIndex+1)) + "/15";
                if ((nextCheckpointSingleIndex + 1) == 15)
                {
                    lapcountP2++;
                    if(lapcountP2 == Laps+1 && lapcountP1 != Laps+1 && lapcountP1 < Laps+1)
                    {
                        txtWinner.enabled = true;
                        txtWinner.text = Convert.ToString("Winner\r\nPlayer2");
                    }
                    else
                    {
                        txtLapCountP2.text = Convert.ToString("Lap: " + lapcountP2 + "/" + Laps);
                    }
                    
                }
            }

            
        } 
        else 
        {
            // Wrong checkpoint
            Debug.Log("Wrong");
            OnPlayerWrongCheckpoint?.Invoke(this, EventArgs.Empty);

            CheckpointSingle correctCheckpointSingle = checkpointSingleList[nextCheckpointSingleIndex];
            correctCheckpointSingle.Show();
        }
    }


}
