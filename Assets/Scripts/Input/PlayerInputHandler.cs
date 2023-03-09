using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerControll playerControll;
    
    public Vector2 RawMovementInput { get; private set; }
    public Vector2 joystickLook;
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool GrabInput { get; private set; }
    public bool IsPc = true;
    public Vector2 MousePosition { get; private set; }

    [SerializeField] private float inputHoldTime = 0.2f;

    [SerializeField] private float jumpInputStartTime;

    private void OnEnable()
    {
        playerControll.Enable();
    }

    private void OnDisable()
    {
        playerControll.Disable();
    }

    private void Awake()
    {
        playerControll = new PlayerControll();
        playerInput = GetComponent<PlayerInput>();
        playerControll.Player.Jump.performed += OnJumpInput;
        playerInput.onControlsChanged += OnDeviceChange;
    }

    private void Update()
    {
        CheckInputHoldTime();
        OnMoveInput();
        Look();
        MousePosition = Mouse.current.position.ReadValue();
    }

    public void OnMoveInput()
    {
        RawMovementInput = playerControll.Player.Move.ReadValue<Vector2>();
    }

    public void Look()
    {
        joystickLook = playerControll.Player.GamepadLook.ReadValue<Vector2>();
        MousePosition = playerControll.Player.MouseLook.ReadValue<Vector2>();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GrabInput = true;
        }

        if (context.canceled)
        {
            GrabInput = false;
        }
    }

    public void UseJumpInput() => JumpInput = false;

    private void CheckInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

    public void OnDeviceChange(PlayerInput pi)
    {
        IsPc = playerInput.currentControlScheme.Equals("PC") ? true : false;
    }
}