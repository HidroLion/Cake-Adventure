using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 moveVector;
    float x, y;

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
    }

    void Flip(float look)
    {
        transform.localScale = new Vector3(look, 1, 1);
    }
}
