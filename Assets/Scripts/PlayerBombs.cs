using UnityEngine;

public class PlayerBombs : MonoBehaviour
{
    public int stars;
    [SerializeField] int maxStars;
    [SerializeField] AudioClip blink;
    [SerializeField] GameObject bombAvaliable;
    AudioSource audioSource;
    bool canBomb;

    [SerializeField] GameObject bomb;

    private void Start()
    {
        bombAvaliable.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star"))
        {
            stars++;
            audioSource.PlayOneShot(blink);
            collision.gameObject.SetActive(false);
            if(stars%maxStars == 0)
            {
                bombAvaliable.SetActive(true);
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
                bombAvaliable.SetActive(false);
                Instantiate(bomb, transform.position, Quaternion.identity);
                canBomb = false;
            }
        }
    }
}
