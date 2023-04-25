using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public float TimeBeforeAffected; 
    private TimeManager timemanager;
    private Rigidbody rb;
    private Vector3 recordedVelocity;
    private float recordedMagnitude;

    private float TimeBeforeAffectedTimer;
    private bool CanBeAffected;
    private bool IsStopped;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        TimeBeforeAffectedTimer = TimeBeforeAffected;
    }

   
    void Update()
    {
        TimeBeforeAffectedTimer -= Time.deltaTime; 
        if (TimeBeforeAffectedTimer <= 0f)
        {
            CanBeAffected = true; 
        }

        if (CanBeAffected && timemanager.TimeIsStopped && !IsStopped)
        {
            if (rb.velocity.magnitude >= 0f) 
            {
                recordedVelocity = rb.velocity.normalized; 
                recordedMagnitude = rb.velocity.magnitude; 

                rb.velocity = Vector3.zero; 
                rb.isKinematic = true; 
                IsStopped = true; 
            }
        }

    }
    public void ContinueTime()
    {
        rb.isKinematic = false;
        IsStopped = false;
        rb.velocity = recordedVelocity * recordedMagnitude; 
    }
}