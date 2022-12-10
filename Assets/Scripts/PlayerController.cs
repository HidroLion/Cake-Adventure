using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float health;
    [SerializeField] Animator animator;
    [SerializeField] GameObject puff;

    AudioSource audioSource;
    Vector3 moveVector;
    float x, y;

    float t;
    bool gameOver;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameOver = false;
        t = 0;
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        moveVector = new Vector3(x, y, 0f);

        transform.position += moveVector * speed * Time.deltaTime;

        if (x < 0f)
            Flip(-1);
        else if (x > 0f)
            Flip(1);

        if (x != 0 || y != 0)
        {
            animator.SetBool("Walk", true);
        }
        else if (x == 0 || y == 0)
        {
            animator.SetBool("Walk", false);
        }

        if (gameOver)
        {
            t += Time.deltaTime;
            if(t >= 0.4)
            {
                SceneManager.LoadScene("Main Scene");
            } 
        }
    }

    void Flip(float look)
    {
        transform.localScale = new Vector3(look, 1, 1);
    }

    public void TakeDamage(float damage)
    {
        animator.SetTrigger("Hurt");
        audioSource.Play();
        health -= damage;
        Debug.Log("[Player] - Take Damage: " + damage.ToString());

        if (health < 0f)
        {
            Instantiate(puff, transform.position, Quaternion.identity);
            gameOver = true;
            Debug.Log("[Player Killed] - Game Over");
        }
    }
}
