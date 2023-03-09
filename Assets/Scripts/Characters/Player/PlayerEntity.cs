using UnityEngine;

public class PlayerEntity : Character
{
    #region State Variables

    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }

    #endregion

    #region Components

    public Animator Anim { get; private set; }

    public PlayerInputHandler InputHandler;
    public Rigidbody RB { get; private set; }

    public Vector3 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    public Collider2D Player_Collider { get; private set; }

    #endregion

    #region CheckTransforms

    [SerializeField] private Transform groundCheck;

    #endregion

    #region Other Variables

    [SerializeField] private PlayerData playerData;

    [SerializeField] private Vector3 workSpace;
    [SerializeField] private bool isGrounded;

    #endregion

    #region Unity Callback Functions

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        FacingDirection = 1;
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody>();
        Player_Collider = GetComponent<Collider2D>();
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
        LookOnCursor();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #endregion

    #region Set Functions

    public void SetVelocityZero()
    {
        RB.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workSpace.Set(angle.x * velocity * direction, transform.position.y, angle.y * velocity);
        RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, CurrentVelocity.y, CurrentVelocity.y);
        RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    public void SetVelocityY(float velocity)
    {
        workSpace.Set(CurrentVelocity.x, velocity, CurrentVelocity.z);
        RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    public void SetVelocityZ(float velocity)
    {
        workSpace.Set(CurrentVelocity.x, CurrentVelocity.y, velocity);
        RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    void LookOnCursor()
    {
        Vector3 moveRotation = new Vector3(InputHandler.RawMovementInput.x, 0f, InputHandler.RawMovementInput.y);
        if (InputHandler.IsPc)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(InputHandler.MousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 rotationTarget = hit.point;

                var lookPos = rotationTarget - transform.position;
                lookPos.y = 0;

                var rotation = Quaternion.LookRotation(lookPos);
                Vector3 aimDirection = new Vector3(rotationTarget.x, 0f, rotationTarget.z);

                if (aimDirection != Vector3.zero)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.4f);
                }
                else
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveRotation), 0.4f);
                }
            }
        }
        else
        {
            Vector3 aimDirection = new Vector3(InputHandler.joystickLook.x, 0f, InputHandler.joystickLook.y);
            if (aimDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(aimDirection), 0.4f);
            }
            else if(moveRotation != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveRotation), 0.4f);
            }
        }
    }

    #endregion

    #region Check Functions

    public bool CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, playerData.groundCheckRadius,
            playerData.WhatIsGround);
        return Physics.CheckSphere(groundCheck.position, playerData.groundCheckRadius, playerData.WhatIsGround);
    }
    
    public bool IsAiming()
    {
        return true;
    }

    #endregion

    #region Other Functions

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    

    #endregion
}