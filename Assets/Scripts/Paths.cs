using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paths : MonoBehaviour
{
    [SerializeField] private float waypointSize = 1f;

    private void OnDrawGizmos()
    {
        foreach (Transform a in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(a.position, waypointSize);
        }

        Gizmos.color = Color.black;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
    }
    public Transform GetNextObjt(Transform currentWaypoint)
    {
        if (currentWaypoint == null)
        {
            return transform.GetChild(0);

        }
        if (currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
        {
            return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }
        else
        {
            return transform.GetChild(0);
        }
    }
}
