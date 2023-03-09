using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected EnemyEntity entity;

    protected float startTime;

    protected string animationBoolName;

    public EnemyState(EnemyEntity entity, EnemyStateMachine stateMachine, string animationBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animationBoolName = animationBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        // entity.Anim.SetBool(animationBoolName, true);
    }

    public virtual void Exit()
    {
        // entity.Anim.SetBool(animationBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
}
