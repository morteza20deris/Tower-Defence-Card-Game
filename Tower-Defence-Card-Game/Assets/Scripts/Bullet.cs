using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 10f;
    public float bulletDamage = 50f;
    public GameObject turretParent;

    public float bulletTime = 10f;
    private void bulletMovement()
    {
        Vector3 dir = transform.forward * Time.deltaTime * bulletSpeed;
        transform.Translate(dir, Space.World);
        // transform.position += transform.forward * Time.deltaTime * bulletSpeed;
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
        // Debug.Log("test1");
        if (other.tag == "Enemy")
        {
            // Debug.Log("test2");
            Enemy hitEnemy = other.gameObject.GetComponent<Enemy>();
            float gainedExp = hitEnemy.expGainOnKill;
            hitEnemy.damage(bulletDamage);

            if (hitEnemy.enemyHealthRemaining <= 0 || hitEnemy.gameObject == null)
            {
                // Debug.Log("test3");
                turretParent.GetComponent<Turret>().eXP += 10f;
                // Destroy(hitEnemy.gameObject);
            }

        }
        Destroy(this.gameObject);

    }
}
