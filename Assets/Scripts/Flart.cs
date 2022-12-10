using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flart : MonoBehaviour
{
    [SerializeField] GameObject fun;
    [SerializeField] Transform funPos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(fun, funPos.position, Quaternion.identity);
        }
    }
}
