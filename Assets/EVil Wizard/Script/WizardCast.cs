using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WizardCast : MonoBehaviour
{
     public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public int attackDamage = 40;
    public float attackRate = 2f;

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Fire();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Fire()
    {
        animator.SetTrigger("Fire");
        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(attackPoint.position,
            attackRange, playerLayer);

        foreach (Collider2D player in hitplayer)
        {
            player.GetComponent<DragonHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
