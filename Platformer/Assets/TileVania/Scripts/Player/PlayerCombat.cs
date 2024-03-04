using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] LayerMask ememyLayer;

    [SerializeField] int attackDamage = 10;

    [SerializeField] float attackRate = 2f;
    private float nextAttackTime = 0f;

    private void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, ememyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            enemy.GetComponent<EnemyMovement>().shouldStopMoving = true;
        }
    }

    #if(UNITY_EDITOR)
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    #endif
}
