using UnityEngine;

public class Enemy1 : EnemyEntity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;

    public override void Start()
    {
        base.Start();

        moveState = new E1_MoveState(this, StateMachine, "move", moveStateData, this);
        idleState = new E1_IdleState(this, StateMachine, "idle", idleStateData, this);
        Agent.speed = moveStateData.MovementSpeed;

        StateMachine.Initialize(moveState);
    }

    public override void Update()
    {
        base.Update();
        transform.LookAt(player.transform);
    }
}