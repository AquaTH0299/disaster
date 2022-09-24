using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthy : MonoBehaviour
{
    bool isDead = false;
    public bool IsDead()
    {
        return isDead;
    }
    [SerializeField] float hitPoints = 100f;
    // created a public method which reduces hitPoints by the amount of damage
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
    }
}
