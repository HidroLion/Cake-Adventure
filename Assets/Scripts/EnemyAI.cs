using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Paths objectives;
    [SerializeField] private float patrolSpeed = 5f;

    bool delayMovement;

    float timer;
    [SerializeField] float delayTime;

    private Transform currentWaypoint;

    void Start()
    {
        currentWaypoint = objectives.GetNextObjt(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = objectives.GetNextObjt(currentWaypoint);
    }

    void Update()
    {

    }

    public void Move(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) == 0)
        {
            currentWaypoint = objectives.GetNextObjt(currentWaypoint);
            Debug.Log("[Waypoint Check] Finish Movement - Starting Delay");
        }
    }
}
