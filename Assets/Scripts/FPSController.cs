using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 17f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float crouchSpeed;
    public float walkSpeedTemp;
    public float runSpeedTemp;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;
    public bool isCrouch = false;

    CharacterController characterController;

     void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Awake()
    {
        crouchSpeed = walkSpeed / 2;
        walkSpeedTemp = walkSpeed;
        runSpeedTemp = runSpeed;
    }

    void Update()
    {
        // movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // press shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float movementDirectionY = moveDirection.y;

      
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        movementDirectionY = moveDirection.y;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        

        // jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {

            moveDirection.y -= gravity * Time.deltaTime;
        }

        // camera
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }


        // crouch 
        if (Input.GetKey(KeyCode.C))
        {
            characterController.height = 0.8f;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;
            isCrouch = true;
          
        }
        else 
        {
            characterController.height = 2f;
            walkSpeed = walkSpeedTemp;
            runSpeed = runSpeedTemp;
            isCrouch = false;
        }
    }
 }

