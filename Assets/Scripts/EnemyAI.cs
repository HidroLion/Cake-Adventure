using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float patrolSpeed;

    bool wait;
    int state;

    float timer;
    [SerializeField] float waitTime;

    [SerializeField] private Transform patrolA;
    [SerializeField] private Transform patrolB;
    Transform patrolC;

    [Header("AI")]
    [SerializeField] Transform target;
    [SerializeField] float distanceTarget;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.enabled = false;

        timer = 0;
        wait = false;
        transform.position = patrolA.position;
        patrolC = patrolB;
    }

    void Update()
    {
        switch (state)
        {
            case 0:
                if (!wait)
                    Patrol();
                else if (wait)
                {
                    timer += Time.deltaTime;
                    if(timer > waitTime)
                    {
                        timer = 0;
                        wait = false;
                    }
                }
                break;
            
            case 1:
                if (!wait)
                    Follow();
                else if (wait)
                {
                    timer += Time.deltaTime;
                    if (timer > waitTime)
                    {
                        timer = 0;
                        wait = false;
                    }
                }
                break;
            case 2:
                RestartPatrol();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            state = 1;
            wait = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wait = false;
            state = 2;
        }
    }

    public void Move(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolC.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, patrolC.position) <= distanceTarget)
        {
            if (patrolC == patrolB)
                patrolC = patrolA;
            else if (patrolC == patrolA)
                patrolC = patrolB;

            wait = true;
        }

        if(transform.position.x > patrolC.position.x)
        {
            Flip(-1);
        }
        else if (transform.position.x < patrolC.position.x)
        {
            Flip(1);
        }
    }

    void Flip(float look)
    {
        transform.localScale = new Vector3(look, 1, 1);
    }

    void Patrol()
    {
        if (!wait)
        {
            Move(patrolSpeed);
        }

        if (wait)
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                wait = false;
                timer = 0;
            }
        }
    }

    void Follow()
    {
        if (!wait)
        {
            agent.enabled = true;
            agent.SetDestination(target.position);
        }

        if (Vector3.Distance(transform.position, target.position) <= distanceTarget * 2)
        {
            wait = true;
            agent.enabled = false;
        }

        if (transform.position.x > target.position.x)
        {
            Flip(-1);
        }
        else if (transform.position.x < target.position.x)
        {
            Flip(1);
        }
    }

    void RestartPatrol()
    {
        agent.enabled = true;
        agent.SetDestination(patrolC.position);
        if(Vector3.Distance(transform.position, patrolC.position) <= distanceTarget)
        {
            state = 0;
        }

        if (transform.position.x > patrolC.position.x)
        {
            Flip(-1);
        }
        else if (transform.position.x < patrolC.position.x)
        {
            Flip(1);
        }
    }
}
