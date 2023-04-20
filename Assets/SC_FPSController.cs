using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]


public class SC_FPSController : MonoBehaviour
{

    public float walkingspeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float JumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXlimit = 45.0f;

    CharacterController CharacterController;
    Vector3 moveDirection = Vector3.zero;
    float rotaionX = 0;
    [HideInInspector]
    public bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 foward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curspeedX = canMove ? (isRunning ? runningSpeed : walkingspeed) * Input.GetAxis("Vertical") : 0;
        float curspeedY = canMove ? (isRunning ? runningSpeed : walkingspeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (foward * curspeedX) + (right * curspeedY);

        if (Input.GetButton("Jump") && canMove && CharacterController.isGrounded)
        {
            movementDirectionY = JumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        if (!CharacterController.isGrounded)
        {
            movementDirectionY -= gravity * Time.deltaTime;
        }
        CharacterController.Move(moveDirection * Time.deltaTime);
        if (canMove)
        {
            rotaionX += Input.GetAxis("Mouse Y") * lookSpeed;
            rotaionX = Mathf.Clamp(rotaionX, -lookXlimit, lookXlimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotaionX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}

