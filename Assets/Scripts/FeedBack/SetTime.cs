using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetTime : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text textTime;
    float timeTotal;

    private void Start()
    {
        timeTotal = Timer.t;
        textTime.text = timeTotal.ToString(".0#");
    }
}
