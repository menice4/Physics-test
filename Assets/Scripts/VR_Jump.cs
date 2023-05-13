using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;

public class VR_Jump : MonoBehaviour
{
    //[SerializeField] private InputActionReference jumpbutton;
    [SerializeField] private float jumpHeight = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;
    private InputDevice targetDevice;
    public InputDeviceCharacteristics inputDeviceCharacteristics;
    

    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool Pressed = false;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

    }
    /*private void onEnable()
    {
        jumpbutton.action.performed += Jumping;
        Debug.Log("jumping");
    }*/

   /* private void OnDisable()
    {
        jumpbutton.action.performed -= Jumping;
    }*/



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

    private void Update()
    {
        if (!targetDevice.isValid)
        {
            Initlize();
        }
       targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool PrimaryButtonValue);
       if (PrimaryButtonValue == true  )
        {
            
            Jumping();
           ;
        }
       else if (PrimaryButtonValue == false && Pressed == true)
        {
            ;
        }
       

       if(characterController.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);

    }


    private void Jumping()
    {
                if (!characterController.isGrounded) return;
        playerVelocity.y += MathF.Sqrt(jumpHeight * -3.0f * gravityValue);

    }
        }


   
  


