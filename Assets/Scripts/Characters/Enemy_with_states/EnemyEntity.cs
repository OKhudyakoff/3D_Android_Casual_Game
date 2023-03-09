using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody),typeof(Animator),typeof(NavMeshAgent))]
public class EnemyEntity : Character
{
    public EnemyStateMachine StateMachine;
    public Rigidbody Rb { get; private set; }
    public NavMeshAgent Agent { get; private set; }
    public Animator Anim { get; private set; }
    
    public D_Entity entityData;

    public PlayerEntity player
    {
        get { return LevelManager.Current.Player; }
        private set { }
    }
    

    private Vector2 velocityWorkspace;

    public virtual void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();

        StateMachine = new EnemyStateMachine();
    }

    public virtual void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        Rb.velocity = velocityWorkspace;
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Vector3.Distance( transform.position, player.transform.position) <= entityData.minAgroDistance;
    }
}