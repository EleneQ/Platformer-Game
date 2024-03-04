using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 1f;

    [HideInInspector] public bool shouldStopMoving = false;
    float currentTime = 0f;
    [SerializeField] float startingTime = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentTime = startingTime;
    }

    private void Update()
    {
        CountdownAfterAttack();
        Move();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        { transform.localScale = new Vector2(-transform.localScale.x, 1f); }
    }

    private void Move()
    {
        Vector3 direction = new Vector3(moveSpeed, 0f, 0f);
        if (IsFacingRight())
        {
            rb.MovePosition(transform.position + direction * Time.deltaTime);
        }
        else
        {
            rb.MovePosition(transform.position - direction * Time.deltaTime);
        }
    }

    bool IsFacingRight()
    {
        return transform.localScale.x > 0f;
    }

    private void CountdownAfterAttack()
    {
        if (shouldStopMoving)
        {
            if(currentTime > 0f)
            {
                currentTime -= 1f * Time.deltaTime;
                rb.bodyType = RigidbodyType2D.Static;
                return;
            }
            else
            {
                rb.bodyType = RigidbodyType2D.Kinematic;
                currentTime = startingTime;

                shouldStopMoving = false;
            }
        }
    }
}
