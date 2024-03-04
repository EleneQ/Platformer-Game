using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] CapsuleCollider2D capsCol;
    [SerializeField] BoxCollider2D boxCol;
    [SerializeField] EnemyMovement movement;

    [SerializeField] int maxHealth = 30;
    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetBool("IsDead", true);

        boxCol.enabled = false;
        capsCol.enabled = false;

        movement.enabled = false;
        this.enabled = false;
    }
}