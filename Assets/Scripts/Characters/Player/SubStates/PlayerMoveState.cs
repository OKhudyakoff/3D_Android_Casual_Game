using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerEntity player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) :
        base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        // player.CheckIfShouldFlip(xInput);
        player.SetVelocityX(xInput * Time.fixedDeltaTime * playerData.movementVelocity);
        player.SetVelocityZ(zInput * Time.fixedDeltaTime * playerData.movementVelocity);
        if (xInput == 0 && zInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}