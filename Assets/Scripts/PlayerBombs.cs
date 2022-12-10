using UnityEngine;

public class PlayerBombs : MonoBehaviour
{
    public int stars;
    [SerializeField] int maxStars;
    bool canBomb;

    [SerializeField] GameObject bomb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star"))
        {
            stars++;
            collision.gameObject.SetActive(false);
            if(stars%maxStars == 0)
            {
                canBomb = true;
                Debug.Log("[Player] - Bomb Ready");
            }
        }
    }

    private void Update()
    {
        if (canBomb)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Instantiate(bomb, transform.position, Quaternion.identity);
                canBomb = false;
            }
        }
    }
}
