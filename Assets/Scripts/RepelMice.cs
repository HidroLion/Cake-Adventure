using UnityEngine;

public class RepelMice : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 vectorDif;

    [SerializeField] float fartForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("[Enemy] Hit");
            rb = collision.GetComponentInParent<Rigidbody2D>();

            vectorDif = collision.transform.position - transform.position;
            vectorDif.Normalize();

            rb.AddForce(vectorDif * fartForce);
        }
    }
}