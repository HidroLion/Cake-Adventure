using UnityEngine;

public class DestroyAtTime : MonoBehaviour
{
    [SerializeField] float lifeTime;
    float timer;

    private void Awake()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifeTime)
            Destroy(gameObject);
    }
}
