using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_IdleState : EnemyIdleState
{
    private Enemy1 enemy;
    public E1_IdleState(EnemyEntity entity, EnemyStateMachine stateMachine, string animationBoolName, D_IdleState stateData, Enemy1 enemy) : base(entity, stateMachine, animationBoolName, stateData)
    {
        this.enemy = enemy;
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
        // if(isPlayerInMinAgroRange)
        // {
        //     stateMachine.ChangeState(enemy.playerDetectedState);
        // }
        if(!isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
