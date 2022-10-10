using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMotor : MonoBehaviour
{
    CharacterController controller;
    Vector3 playerVelocity;
     bool isGrounded;
    bool isCrouch;
    bool isRun;
    bool isLerpCrouch;
    //
    [SerializeField] float Gravity = -9.8f;
    [SerializeField] float Speed = 10f;
    [SerializeField] float JumpHeight = 10f;
    [SerializeField] float CrouchTimer;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isLerpCrouch)
        {
            CrouchLerp();
        }
    }
    public void ProccessMove(Vector2 input)
    {
      
        Vector3 DirectMove = Vector3.zero;
        DirectMove.x = input.x;
        DirectMove.z = input.y;
        //move with keyboard
        controller.Move(transform.TransformDirection(DirectMove) * Speed * Time.deltaTime);
        controller.Move(transform.TransformDirection(DirectMove) * Speed * Time.deltaTime);
 
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        //
        playerVelocity.y += Gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }

    public void Jump()
    {
        
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(JumpHeight * -3f * Gravity);
        }
        

    }

    // ngoi
    void CrouchLerp()
    {
        CrouchTimer += Time.deltaTime;

        float p = CrouchTimer / 1;
        p *= p;
        if (isCrouch)
        {
            controller.height = Mathf.Lerp(controller.height, 1, p);
        }
        else
        {
            controller.height = Mathf.Lerp(controller.height, 2, p);
        }
        if (p > 1)
        {
            isCrouch = false;
            CrouchTimer = 0;
        }
    }
    public void Crouch()
    {
        isCrouch = !isCrouch;
        CrouchTimer = 0;

        isLerpCrouch = true;

    }

    // chay
    public void Sprint()
    {
        isRun = !isRun;
        if (isRun)
        {
            Speed = 25;
        }
        else
        {
            Speed = 10;
        }
    }
}
