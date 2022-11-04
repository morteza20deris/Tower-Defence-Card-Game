using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHealth = 100f;

    public void damage(float damageAmount)
    {
        enemyHealth -= damageAmount;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
