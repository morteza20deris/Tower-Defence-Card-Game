using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float enemyHealth = 100f;
    public float enemyHealthRemaining;
    public Image healthBar;
    public float expGainOnKill = 10f;
    public float worth = 10f;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        enemyHealthRemaining = enemyHealth;
    }

    public void damage(float damageAmount)
    {

        enemyHealthRemaining -= damageAmount;
        healthBar.fillAmount = enemyHealthRemaining / enemyHealth;
        if (enemyHealthRemaining <= 0)
        {
            Destroy(gameObject);
            Shop.instance.bank(worth, 0);

        }
    }
}
