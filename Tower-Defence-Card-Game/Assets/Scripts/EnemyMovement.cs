using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    // private SphereCollider enemyCollider;
    private int targetIndex;

    private bool toRun = false;



    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {

        // Debug.Log("enemy Movement started");

        // enemyCollider = this.GetComponent<SphereCollider>();

        if (wayPoints.wayPoint.Length > 0)
        {
            targetIndex = 0;
            toRun = true;
        }
        else
        {
            toRun = false;
        }
        target = wayPoints.wayPoint[targetIndex];

    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    //  <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision: " + other.gameObject.name);


        if (other.gameObject.name == "Home")
        {
            Debug.Log(gameObject.name + " is destroyed");
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehavior is enabled.
    /// </summary>
    void Update()
    {
        if (toRun)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


            if (dir.magnitude < 1)
            {
                if (targetIndex < wayPoints.wayPoint.Length - 1)
                {
                    targetIndex++;
                    target = wayPoints.wayPoint[targetIndex];

                }
            }
        }



    }
}
