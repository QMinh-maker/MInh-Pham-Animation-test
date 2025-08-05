using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHealth : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Nguoi choi chet.");
        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        // Tắt các script điều khiển 
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (var script in scripts)
        {
            if (script != this)
                script.enabled = false;
        }

        // Gọi hàm biến mất sau 1.5s (thời gian để animation chết chạy xong)
        Invoke(nameof(Disappear), 1.5f);
    }

    void Disappear()
    {
        Destroy(gameObject);
    }      
    
}
