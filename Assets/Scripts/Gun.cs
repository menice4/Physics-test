using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    private Camera cam;
    private InputDevice targetDevice;
    public InputDeviceCharacteristics inputDeviceCharacteristics;
    private bool Fired;
   

    void Start()
    {
        
    }

    private void Initlize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightcontrollerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightcontrollerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }

    }
    /*{
        StartCoroutine(GetDevices(3.0f));
    }
    IEnumerator GetDevices(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightcontrollerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightcontrollerCharacteristics, devices);
        InputDevices.GetDevices(devices);

        Debug.Log("Enumerating XR Devices...");
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
        Debug.Log("Finished!");
    }*/

 
  







    void Update()
    {
        
        if (!targetDevice.isValid)
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
        if (Fired == false && triggerValue > 0.8  )
        {
            
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            Fired = true;



        }
        else if (Fired == true && triggerValue < 0.5)
        {
            
            Fired = false;

        }
    }
    /*if ((0))
    {


        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }*/
}
 
