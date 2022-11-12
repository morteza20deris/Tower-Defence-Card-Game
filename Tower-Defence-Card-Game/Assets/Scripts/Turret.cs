using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public float distance = 10f;
    public GameObject bullet;
    public float bulletDamage = 10f;
    public GameObject bulletParent;
    public float bulletSpeed = 10f;
    public float eXP = 0f;
    public int lvl = 0;
    public float turretLvlUpFactor = 100f;
    public GameObject bulletShooter;
    public float rotationSpeed = 10f;
    public float scanInterval = 0.5f;
    public float BPSBulletsPerSecond = 1f;
    public float turretPrice = 100f;
    private GameObject nearestEnemy = null;
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (!nearestEnemy)
        {
            if (useLaser)
            { lineRenderer.enabled = false; }
            return;
        }


        rotationOfTurret();

    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        InvokeRepeating("sensor", 0, scanInterval);
        if (useLaser == false)
        {
            InvokeRepeating("bulletSpawner", 0, 1f / BPSBulletsPerSecond);

        }
        else
        {
            InvokeRepeating("Laser", 0, 1f / BPSBulletsPerSecond);
        }
    }

    private void levelUP()
    {
        if (eXP > lvl * turretLvlUpFactor)
        {
            lvl++;
            rotationSpeed *= 1.2f;
            BPSBulletsPerSecond *= 1.2f;
            bulletDamage *= 1.2f;
            bulletSpeed *= 1.2f;
            eXP = 0;
        }
    }

    private void Laser()
    {
        if (!nearestEnemy)
        {
            return;
        }
        if (!lineRenderer.enabled && nearestEnemy)
        {
            lineRenderer.enabled = true;
        }
        lineRenderer.SetPosition(0, bulletShooter.transform.position);
        lineRenderer.SetPosition(1, nearestEnemy.transform.position);
        if (nearestEnemy)
        {
            nearestEnemy.GetComponent<Enemy>().damage(bulletDamage);
            if (nearestEnemy.GetComponent<Enemy>().enemyHealthRemaining <= 0)
            {
                eXP += nearestEnemy.GetComponent<Enemy>().expGainOnKill;
            }
        }
    }

    /// <summary>
    /// rotation of turret is called when there is enemy in range and rotates the turret in the direction of enemy
    /// </summary>

    private void rotationOfTurret()
    {
        if (nearestEnemy)
        {
            Vector3 enemyDirection = (nearestEnemy.transform.position - transform.position).normalized;
            Quaternion lookDirection = Quaternion.LookRotation(enemyDirection);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookDirection, Time.deltaTime * rotationSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

    }


    /// <summary>
    /// sensor is called every scanInterval it scans and finds the nearest enemy in specified distance
    /// </summary>

    private void sensor()
    {
        Debug.Log("scanning");
        // nearestEnemy = null;
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        if (targets.Length > 0)
        {
            Debug.Log(targets[0].name + " is first enemy");
        }
        else
        {
            Debug.Log("no enemy");
        }
        foreach (GameObject item in targets)
        {
            if (nearestEnemy)
            {
                float newDistance = Vector3.Distance(item.transform.position, transform.position);
                float oldDistance = Vector3.Distance(nearestEnemy.transform.position, transform.position);
                if (newDistance < oldDistance)
                {
                    nearestEnemy = item;
                    Debug.Log("nearestEnemy= " + nearestEnemy.name);
                }

                if (Vector3.Distance(nearestEnemy.transform.position, transform.position) > distance)
                {
                    nearestEnemy = null;
                }
            }
            else
            {
                float enemyDistance = Vector3.Magnitude(item.transform.position - transform.position);
                if (enemyDistance < distance)
                {
                    nearestEnemy = item;

                    Debug.Log("nearestEnemy= " + nearestEnemy.name);
                }
            }
        }



    }

    /// <summary>
    /// Callback to draw gizmos only if the object is selected.
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, distance);
    }


    private void bulletSpawner()
    {
        if (nearestEnemy != null && useLaser == false)
        {
            if (lineRenderer && lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }
            Debug.Log("shooting");
            GameObject newBullet = Instantiate(bullet, bulletShooter.transform.position, bulletShooter.transform.rotation);
            // newBullet.transform.parent = bulletParent.transform;
            newBullet.GetComponent<Bullet>().turretParent = this.gameObject;
            newBullet.GetComponent<Bullet>().bulletDamage = bulletDamage;
            newBullet.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
            levelUP();

        }

    }
}
