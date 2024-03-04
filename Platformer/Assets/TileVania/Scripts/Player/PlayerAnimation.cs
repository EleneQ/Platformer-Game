using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] PlayerMovement playerMovement;

    private void Update()
    {
        Run();
        Climb();
    }

    private void Run()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > 0.01f;
        anim.SetBool("Run", playerHasHorizontalSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazards") ||
            other.CompareTag("Enemy"))
        {
            anim.SetTrigger("Dying");
        }
    }

    private void Climb()
    {
        if(playerMovement.isGrounded)
        {
            anim.SetBool("Climbing", false);
            return;
        }
  
        bool playerHasVerticalSpeed = Mathf.Abs(rb.velocity.y) > 0.01f;
        anim.SetBool("Climbing", playerHasVerticalSpeed);
    }
}
