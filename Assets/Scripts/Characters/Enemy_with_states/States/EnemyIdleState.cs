using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected D_IdleState stateData;
    protected bool isPlayerInMinAgroRange;

    public EnemyIdleState(EnemyEntity entity, EnemyStateMachine stateMachine, string animationBoolName,
        D_IdleState stateData) : base(entity, stateMachine, animationBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0f);
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        entity.Agent.SetDestination(entity.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        entity.Agent.SetDestination(entity.transform.position);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }
}