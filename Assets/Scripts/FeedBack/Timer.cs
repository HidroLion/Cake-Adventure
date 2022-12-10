using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text textTime;
    Collectables collectables;

    public static float t;

    private void Start()
    {
        collectables = GetComponent<Collectables>();
    }

    private void Update()
    {
        if (!collectables.win)
        {
            t += Time.deltaTime;

            textTime.text = t.ToString(".0#");
        }

        if (collectables.win)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
