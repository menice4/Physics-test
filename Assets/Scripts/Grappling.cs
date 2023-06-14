using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Grappling : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    Transform bulletTransform;
    public float bulletSpeed = 10;
    Rigidbody bulletRb;
    private Camera cam;
    private InputDevice targetDevice;
    public InputDeviceCharacteristics inputDeviceCharacteristics;
    private bool Fired;
    hook hookScript;
    private GameObject player;
    private Transform playerTransform;
    SpringJoint springJoint;
   

    void Start()
    {
        bulletTransform = bulletPrefab.transform;
        hookScript = bulletPrefab.GetComponent<hook>();
        bulletRb = bulletPrefab.GetComponent<Rigidbody>();
        Initlize();
        player = GameObject.Find("VR_rig");

        playerTransform = player.transform;
        
    }

    private void Initlize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftcontrollerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftcontrollerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }

    }
 
  







    void Update()
    {
        if(!targetDevice.isValid)
        {
            Initlize();
        }
        else
        {
            UpdateGun();
        }
        
     
   
    }
    private void UpdateGun()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if (Fired == false && triggerValue > 0.8   )
        {
            bulletTransform.position = bulletSpawnPoint.position;
            bulletRb.velocity = bulletSpawnPoint.forward * bulletSpeed;

      
            Fired = true;


        }
        else if (Fired == true && triggerValue < 0.7)
        {
            StopShooting();
            
        }

       
    }
    private void StopShooting()
    {
        hookScript.DestoryJoint();
        bulletTransform.position = bulletSpawnPoint.position;
        bulletTransform.forward = bulletSpawnPoint.forward;
        Destroy(springJoint);
        Fired = false;

    }
    public void Swing()
    {
        springJoint = player.AddComponent<SpringJoint>();
        springJoint.connectedBody = hookScript.collisonObject.GetComponent<Rigidbody>();
        springJoint.autoConfigureConnectedAnchor = false;
        springJoint.connectedAnchor = hookScript.collisonObject.transform.InverseTransformPoint(hookScript.hitPoint);
        springJoint.anchor = Vector3.zero;

        float disJointToPlayer = Vector3.Distance(playerTransform.position, bulletTransform.position);

        springJoint.maxDistance = disJointToPlayer * 0.6f;
        springJoint.minDistance = disJointToPlayer * 0.1f;
        springJoint.damper = 100f;
        springJoint.spring =  500f;
    }

    /*if ((0))
    {


        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }*/
}

