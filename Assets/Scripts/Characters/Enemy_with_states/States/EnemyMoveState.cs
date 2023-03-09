using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    protected D_MoveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinAgroRange;

    public EnemyMoveState(EnemyEntity entity, EnemyStateMachine stateMachine, string animationBoolName, D_MoveState stateData) : base(entity, stateMachine, animationBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        entity.Agent.SetDestination(LevelManager.Current.Player.transform.position);
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        entity.Agent.SetDestination(LevelManager.Current.Player.transform.position);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }
}
