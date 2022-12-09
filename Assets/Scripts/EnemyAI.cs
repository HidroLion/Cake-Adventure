using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Paths objectives;
    [SerializeField] private float patrolSpeed = 5f;

    bool wait;
    int state;

    float timer;
    [SerializeField] float waitTime;

    private Transform currentWaypoint;

    void Start()
    {
        timer = 0;
        wait = false;
        currentWaypoint = objectives.GetNextObjt(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = objectives.GetNextObjt(currentWaypoint);
    }

    void Update()
    {
        if(state == 0)
        {
            if (!wait)
            {
                Move(patrolSpeed);
            }

            if (wait)
            {
                timer += Time.deltaTime;
                if(timer > waitTime)
                {
                    wait = false;
                    timer = 0;
                }
            }
        }
    }

    public void Move(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) == 0)
        {
            currentWaypoint = objectives.GetNextObjt(currentWaypoint);
            Debug.Log("[Waypoint Check] Finish Movement - Starting Delay");
            wait = true;
        }

        if(transform.position.x > currentWaypoint.position.x)
        {
            Flip(-1);
        }
        else if (transform.position.x < currentWaypoint.position.x)
        {
            Flip(1);
        }
    }

    void Flip(float look)
    {
        transform.localScale = new Vector3(look, 1, 1);
    }
}
