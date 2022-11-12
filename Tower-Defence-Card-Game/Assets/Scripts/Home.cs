using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Home : MonoBehaviour
{

    public int lives = 10;
    public TMP_InputField lives_IF;
    public TMP_InputField Money_IF;
    public TMP_Text Money_TXT;
    public TMP_Text livesText;
    private bool gameEnded = false;


    public static Home Instance;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Instance = this;
        Time.timeScale = 1;
        Money_IF.text = Money_TXT.text;
        lives_IF.text = lives + "";
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        // lives_IF.text = lives + "";
    }

    public void LivesChanger()
    {
        if (lives_IF.text == "")
        {
            return;
        }
        if (int.Parse(lives_IF.text) < 0)
        {
            lives = 0;
        }
        else
        {
            lives = int.Parse(lives_IF.text);

        }
        livesText.text = lives + " Lives Left";
    }
    public void MoneyChanger()
    {
        Money_TXT.text = Money_IF.text;
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
