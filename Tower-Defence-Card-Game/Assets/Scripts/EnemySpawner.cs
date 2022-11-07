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
            WaitForSeconds wait = new WaitForSeconds(interval);
            yield return wait;
        }
    }
}
