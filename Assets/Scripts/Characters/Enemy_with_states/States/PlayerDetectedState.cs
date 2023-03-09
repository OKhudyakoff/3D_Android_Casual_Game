using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : EnemyState
{
    protected D_PlayerDetectedState stateData;

    protected bool isPlayerInMinAgroRange;
    public PlayerDetectedState(EnemyEntity entity, EnemyStateMachine stateMachine, string animationBoolName, D_PlayerDetectedState stateData) : base(entity, stateMachine, animationBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0f);

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }
}
