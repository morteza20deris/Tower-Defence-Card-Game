using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TurretBuildManager : MonoBehaviour
{
    public static TurretBuildManager instance;

    float minimumTurretDistance = 10f;
    public TMP_Text coin;

    public GameObject[] turretToBuild;
    private int selectedTurret = -1;

    public GameObject turretParent;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            TurretBuilder(getClickedPos());
        }
    }

    public void getSelectedTurret(int selectedTurretIndex)
    {
        selectedTurret = selectedTurretIndex;
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        instance = this;
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
        if (pos != Vector3.zero && selectedTurret != -1)
        {
            float coins = int.Parse(coin.text.Replace("$", ""));
            Turret turret = turretToBuild[selectedTurret].GetComponent<Turret>();
            if (coins >= turret.turretPrice)
            {
                GameObject newTurret = Instantiate(turretToBuild[selectedTurret], pos, Quaternion.Euler(0, 0, 0));
                newTurret.transform.SetParent(turretParent.transform);
                Shop.instance.bank(0, turret.turretPrice);

            }

        }

    }
}
