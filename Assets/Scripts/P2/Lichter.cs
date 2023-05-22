using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lichter : MonoBehaviour
{
    public Light LichtFR;
    public Light LichtFL;
    public Light LichtRR;
    public Light LichtRL;
    bool Lichtenabled;
    bool brake;
    
    
    
    
    //public Material ShaderR;



    // Start is called before the first frame update
    void Start()
    {        
        LichtFR.enabled = false;
        LichtFL.enabled = false;
        LichtRR.enabled = false;
        LichtRL.enabled = false;
        Lichtenabled = false;
        brake = false;
        LichtRR.intensity = 5;
        LichtRL.intensity = 5;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            LichtRR.enabled = true;
            LichtRL.enabled = true;
            brake = true;
            LichtRR.intensity = 10;
            LichtRL.intensity = 10;
        }
        if (Input.GetKeyUp(KeyCode.Keypad5))
        {
            brake = false;
            LichtRR.intensity = 5;
            LichtRL.intensity = 5;
        }

        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            Lichtenabled = !Lichtenabled;
        }
    }

    void FixedUpdate()
    {
        if (Lichtenabled == true)
        {
            LichtFR.enabled = true;
            LichtFL.enabled = true;
            LichtRR.enabled = true;
            LichtRL.enabled = true;
        }
        else
        {
            LichtFR.enabled = false;
            LichtFL.enabled = false;
            if(brake == false)
            {
                LichtRR.enabled = false;
                LichtRL.enabled = false;
            }
            
        }
    }
}
