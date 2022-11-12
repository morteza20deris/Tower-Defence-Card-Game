using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class EnemySpawner : MonoBehaviour
{


    public GameObject enemy;
    public int interval;
    public TMP_InputField interval_IF;

    public bool infiniteEnemies = false;
    public int enemyCount;
    private GameObject enemyParent;
    [Header("Random Enemy Settings")]
    public bool randomEnemies = false;
    public float enemyHealthMin = 10f;
    public TMP_InputField enemyHealthMin_IF;
    public float enemyHealthMax = 1000f;
    public TMP_InputField enemyHealthMax_IF;
    public float enemySpeedMin = 10f;
    public TMP_InputField enemySpeedMin_IF;
    public float enemySpeedMax = 100f;
    public TMP_InputField enemySpeedMax_IF;
    // Start is called before the first frame update
    void Start()
    {
        enemyParent = new GameObject("Enemy parent");
        enemyParent.transform.position = Vector3.zero;
        StartCoroutine(enemySpawning());
        interval_IF.text = interval + "";
        enemyHealthMin_IF.text = enemyHealthMin + "";
        enemyHealthMax_IF.text = enemyHealthMax + "";
        enemySpeedMin_IF.text = enemySpeedMin + "";
        enemySpeedMax_IF.text = enemySpeedMax + "";
    }


    public void intervalchanger()
    {
        interval = int.Parse(interval_IF.text);
    }
    public void enemyHealthMinChanger()
    {
        enemyHealthMin = int.Parse(enemyHealthMin_IF.text);
    }
    public void enemyHealthMaxChanger()
    {
        enemyHealthMax = int.Parse(enemyHealthMax_IF.text);
    }
    public void enemySpeedMinChanger()
    {
        enemySpeedMin = int.Parse(enemySpeedMin_IF.text);
    }
    public void enemySpeedMaxChanger()
    {
        enemySpeedMax = int.Parse(enemySpeedMax_IF.text);
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
