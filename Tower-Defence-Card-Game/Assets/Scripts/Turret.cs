using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float distance = 10f;
    public int turretAccuracy = 10;
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        for (int i = 0; i <= turretAccuracy; i++)
        {
            float degree = (365 / turretAccuracy) * i;

            Vector3 degree2 = new Vector3(0, degree, 0);

            Debug.DrawRay(transform.position, Quaternion.Euler(0, degree, 0) * Vector3.one * distance, Color.yellow);
        }

    }

    private void sensor()
    {
        for (int i = 0; i <= turretAccuracy; i++)
        {
            float degree = (365 / turretAccuracy) * i;
            Vector3 degree2 = new Vector3(0, degree, 0);
            Ray ray = new Ray(transform.position, Quaternion.Euler(0, degree, 0) * Vector3.one * distance);
            RaycastHit rayData;
            Physics.Raycast(ray, out rayData);


        }
    }

}
