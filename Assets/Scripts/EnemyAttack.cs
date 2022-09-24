using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealthy target;
    [SerializeField] float damage = 45f;
    void Start()
    {
        target = FindObjectOfType<PlayerHealthy>();
    }
    public void AttackHitEvent()
    {
        if( target == null) return;
        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }
}
