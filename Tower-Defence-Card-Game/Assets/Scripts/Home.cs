using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Home : MonoBehaviour
{

    public int lives = 10;
    public TMP_Text livesText;
    private bool gameEnded = false;


    public static Home Instance;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Instance = this;
    }



    public void reduceLives()
    {
        if (lives > 0)
        {
            lives--;
            livesText.text = lives + " Lives Left";
        }
        else if (!gameEnded)
        {
            Debug.Log("Game Over");
            gameEnded = true;

        }
    }
}
