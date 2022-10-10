using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    public PlayerActions.OnFootActions onFoot;
    //
    PlayerActions PlayerInput;
    PlayMotor playerMotor;
    PlayerLook look;
    void Awake ()
    {
        PlayerInput = new PlayerActions() ;
        onFoot = PlayerInput.OnFoot;
        playerMotor =  GetComponent<PlayMotor>();
        look = GetComponent<PlayerLook>();
        onFoot.Jump.performed += ctx => playerMotor.Jump();
        onFoot.Sprint.performed += ctx => playerMotor.Sprint();
        onFoot.Crouch.performed += ctx => playerMotor.Crouch();

    }

   
  
    private void FixedUpdate()
    {
        playerMotor.ProccessMove(onFoot.Moving.ReadValue<Vector2>());
    }
    void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());

    }

    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
