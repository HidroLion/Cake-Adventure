using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class Collectables : MonoBehaviour
{
    [SerializeField] PlayerBombs player;
    [SerializeField] int maxStars;

    [SerializeField] TMPro.TMP_Text textCounter;
    [SerializeField] TMPro.TMP_Text textTotal;

    public bool win;

    private void Start()
    {
        textTotal.text = maxStars.ToString();
    }

    private void Update()
    {
        textCounter.text = player.stars.ToString();

        if(player.stars == maxStars)
        {
            win = true;
        }
    }
}
