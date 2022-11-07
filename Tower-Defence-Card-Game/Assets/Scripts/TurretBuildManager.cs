using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurretBuildManager : MonoBehaviour
{

    float minimumTurretDistance = 10f;
    public TMP_Text coin;

    public GameObject turretToBuild;

    public GameObject turretParent;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TurretBuilder(getClickedPos());
        }
    }


    private Vector3 getClickedPos()
    {
        RaycastHit hit;

        var ray = new Ray();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.point + " is clicked");
            if (hit.transform.tag == "Ground")
            {
                return hit.point;

            }
        }

        return Vector3.zero;
    }

    private void TurretBuilder(Vector3 pos)
    {
        foreach (Transform item in turretParent.GetComponentInChildren<Transform>())
        {
            if (Vector3.Distance(item.transform.position, pos) < minimumTurretDistance)
            {
                Debug.Log("to close to other turrets");
                return;
            }
        }
        if (pos != Vector3.zero)
        {
            float coins = int.Parse(coin.text.Replace("$", ""));
            Turret turret = turretToBuild.GetComponent<Turret>();
            if (coins >= turret.turretPrice)
            {
                GameObject newTurret = Instantiate(turretToBuild, pos, Quaternion.Euler(0, 0, 0));
                newTurret.transform.SetParent(turretParent.transform);
                Shop.instance.bank(0, turret.turretPrice);

            }

        }

    }
}
