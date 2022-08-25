using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Define;

public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Stat")]
    private int health;
    public int Health { set { health = value; health = Mathf.Clamp(health, 0, int.MaxValue); } get { return health; } }

    public float MoveSpeed;

    public int Coin;

    public EnemyTurnDirection Direction;

    private int CurrentTurn;

    private NavMeshAgent agent;

    private bool CanMove;

    private void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
        CanMove = true;
        MoveSpeed = 3f;
    }

    private void Start()
    {
        agent.speed = MoveSpeed;
        CurrentTurn = -1;
        NextStreet();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        if (agent.velocity.sqrMagnitude >= 0.2f * 0.2f && agent.remainingDistance <= 0.7f)
        {
            NextStreet();
        }
    }

    void NextStreet()
    {
        if (agent.isPathStale || !CanMove) return;
        Vector3 next = EnemyNavigation.Instance.NextStreet(Direction, ref CurrentTurn);
        if (next == Vector3.zero)
        {
            Stop();
            return;
        }
        agent.SetDestination(next);
        agent.isStopped = false;
    }

    void Stop()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
        CanMove = false;
    }

    protected abstract void Effect();
}
