public class PlayerGroundedState : PlayerState
{
    protected float xInput;
    protected float zInput;
    private bool JumpInput;
    private bool isTouchingWall;
    public PlayerGroundedState(PlayerEntity player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        player.JumpState.ResetAmountOfJumpsLeft();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.RawMovementInput.x;
        zInput = player.InputHandler.RawMovementInput.y;
        JumpInput = player.InputHandler.JumpInput;

        if(JumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
