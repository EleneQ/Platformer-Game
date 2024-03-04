using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] CapsuleCollider2D col;

    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 25f;
    [SerializeField] float climbSpeed = 5f;

    private float gravityScaleAtStart;
    public bool isGrounded { get; private set; }

    private void Awake()
    {
        gravityScaleAtStart = rb.gravityScale;
    }

    private void Update()
    {
        Run();
        Jump();
        Climb();
        Flip();
    }

    private void Run()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 newVelocity = new Vector2(horizontalInput * runSpeed, rb.velocity.y);
        rb.velocity = newVelocity;
    }

    private void Jump()
    {
        if (!col.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if(Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocity = new Vector2(rb.velocity.x, jumpSpeed);
            rb.velocity += jumpVelocity;
        }
    }

    private void Climb()
    {
        if(!col.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            isGrounded = true;
            rb.gravityScale = gravityScaleAtStart;
            return;
        }

        isGrounded = false;
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 climbVelocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed);
        rb.velocity = climbVelocity;

        rb.gravityScale = 0f;
    }

    private void Flip()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }
}
