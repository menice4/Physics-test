using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public bool TimeIsStopped;

    public void ContinueTime()
    {
        TimeIsStopped = false;

        var objects = FindObjectsOfType<TimeBody>();  
        for (var i = 0; i < objects.Length; i++)
        {
            objects[i].GetComponent<TimeBody>().ContinueTime(); 
        }

    }
    public void StopTime()
    {
        TimeIsStopped = true;
    }
}