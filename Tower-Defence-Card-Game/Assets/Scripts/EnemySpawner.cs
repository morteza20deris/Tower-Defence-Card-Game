using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemySpawner : MonoBehaviour
{


    public GameObject enemy;
    public int interval;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
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
            // GameObject newEnemy = new GameObject("enemy#" + i);
            Instantiate(enemy, transform.position, Quaternion.identity);
            WaitForSeconds wait = new WaitForSeconds(interval);
            yield return wait;
        }
    }
}
