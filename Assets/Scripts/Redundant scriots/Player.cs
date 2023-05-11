using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private TimeManager timemanager;


    void Start()
    {
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //Stop Time when Q is pressed
        {
            timemanager.StopTime();
         
        }
        if (Input.GetKeyDown(KeyCode.E) && timemanager.TimeIsStopped)  //Continue Time when E is pressed
        {
            timemanager.ContinueTime();


        }
    }
}