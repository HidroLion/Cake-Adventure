using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    [SerializeField] GameObject deadMouse;
    [SerializeField] GameObject mouse;
    [SerializeField] float deadTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bomb"))
        {
            Instantiate(deadMouse, transform.position, Quaternion.identity);
            collision.gameObject.SetActive(false);
            mouse.gameObject.SetActive(false);
        }
    }
}
