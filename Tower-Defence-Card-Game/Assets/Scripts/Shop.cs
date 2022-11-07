using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{

    public static Shop instance;
    public TMP_Text coin;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        instance = this;
    }
    public void bank(float add, float remove)
    {

        if (add > 0)
        {
            coin.text = coin.text.Replace("$", "");

            coin.text = int.Parse(coin.text) + add + "$";

        }
        if (remove > 0)
        {
            coin.text = coin.text.Replace("$", "");

            coin.text = int.Parse(coin.text) - remove + "$";
        }


    }
}
