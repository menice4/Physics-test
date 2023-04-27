using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;

    void Start()

    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(rb.velocity.magnitude >= 0f)
        transform.rotation = Quaternion.LookRotation(rb.velocity);
        
    }
    private void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject, 0.05f);
    }
}

