using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthy : MonoBehaviour
{
    private void Awake() 
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }
  [SerializeField] float hitPoints = 100f;
    // created a public method which reduces hitPoints by the amount of damage
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
