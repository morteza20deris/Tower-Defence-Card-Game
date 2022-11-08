using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemySpawner : MonoBehaviour
{


    public GameObject enemy;
    public int interval;


    public bool infiniteEnemies = false;
    public int enemyCount;
    private GameObject enemyParent;
    [Header("Random Enemy Settings")]
    public bool randomEnemies = false;
    public float enemyHealthMin = 10f;
    public float enemyHealthMax = 1000f;
    public float enemySpeedMin = 10f;
    public float enemySpeedMax = 100f;
    // Start is called before the first frame update
    void Start()
    {
        enemyParent = new GameObject("Enemy parent");
        enemyParent.transform.position = Vector3.zero;
        StartCoroutine(enemySpawning());
    }

    // Update is called once per frame
    void Update()
    {

    }



    private IEnumerator enemySpawning()
    {


        for (int i = 0; i <= enemyCount; i++)
        {
            if (infiniteEnemies)
            {
                i = 0;
            }

            // GameObject newEnemy = new GameObject("enemy#" + i);
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            newEnemy.name = "enemy#" + i;
            newEnemy.transform.SetParent(enemyParent.transform);
            if (randomEnemies)
            {
                newEnemy.GetComponent<Enemy>().enemyHealth = Random.Range(enemyHealthMin, enemyHealthMax);
                newEnemy.GetComponent<EnemyMovement>().speed = Random.Range(enemySpeedMin, enemySpeedMax);
            }
            WaitForSeconds wait = new WaitForSeconds(interval);
            yield return wait;
        }
    }
}
