using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook: MonoBehaviour
{
    public Grappling grappling;
    FixedJoint fixedJoint;
    public GameObject collisonObject;
    public Vector3 hitPoint;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            hitPoint = collision.contacts[0].point;
            collisonObject = collision.gameObject;
            fixedJoint = gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
            grappling.Swing();
        }
      
            
     
       
    }
    public void DestoryJoint()
    {
        Destroy(fixedJoint);
        
       
        
        

    }
}
