using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 10f;
    public float bulletDamage = 50f;

    public float bulletTime = 10f;
    private void bulletMovement()
    {
        transform.position += transform.forward * Time.deltaTime * bulletSpeed;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        bulletMovement();
        StartCoroutine("bulletDuration");
    }

    private IEnumerator bulletDuration()
    {
        for (int i = 0; i < bulletTime; i++)
        {
            yield return new WaitForSeconds(1f);
        }
        Destroy(this.gameObject);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            Destroy(this.gameObject);
            if (other.tag == "Enemy")
            {
                Enemy hitEnemy = other.gameObject.GetComponent<Enemy>();
                hitEnemy.damage(bulletDamage);
                Enemy enemy = hitEnemy.gameObject.GetComponent<Enemy>();
                if (hitEnemy.gameObject == null || enemy.enemyHealth <= 0)
                {
                    transform.parent.gameObject.GetComponent<Turret>().eXP += hitEnemy.expGainOnKill;
                }

            }
        }
    }
}
