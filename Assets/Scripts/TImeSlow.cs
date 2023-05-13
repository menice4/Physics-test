using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TImeSlow : MonoBehaviour
{
    public bool Slowed;
    Movment player;
    public float slowAmount = 0.1f;
    public float slowDurtion = .5f;
    private IEnumerator coroutine;
    public bool Move;
    public bool unlock;
    public float Timeleft = .5f;
    private InputDevice targetDevice;
    public InputDeviceCharacteristics inputDeviceCharacteristics;




    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("VR_rig").GetComponent<Movment>();

    }
    void Start()
    {
        unlock = false;
        Move = false;
        Slowed = false;
        Debug.Log("time"+Time.timeScale);
        Debug.Log("Movement speed" + player.movementSpeed);
        Initlize();



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

        if (!targetDevice.isValid)
        {
            Initlize();
        }
        else
        {
            Timestop();
        }
    }

    // Update is called once per frame
    void Timestop()

    {
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if (triggerValue > 0.5 && Slowed == false)
        {
                Slowed = true;
                Move = true;

            Time.timeScale = slowAmount;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        
            
           
            Debug.Log("Movement speed" + player.movementSpeed);


        }
        else if (triggerValue < 0.8 && Slowed == true )
        {
                Slowed = false;
           
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
           

        }


        if (Move == true)

        {
            Move = false;
            print("waiting");
            coroutine = unSlow(Timeleft);
            StartCoroutine(coroutine);
       
            
        }
        if (unlock == true)
        {
            Time.timeScale += (1f / slowDurtion) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            if (Time.timeScale == 1f)
            {
                Slowed = false;
                unlock = false;
            }

     
        }


    }
    
    IEnumerator unSlow(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        unlock = true;
    }



}


