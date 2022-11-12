using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Update is called once per frame
    public GameObject menu;
    public GameObject settingsmenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && settingsmenu.activeSelf == false)
        {
            // Debug.Log(gameObject.activeSelf);

            MenuScreen();


        }
    }

    public void MenuScreen()
    {
        menu.SetActive(!menu.activeSelf);
        if (!menu.activeSelf)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void settingsButton()
    {
        menu.SetActive(!menu.activeSelf);
        settingsmenu.SetActive(!settingsmenu.activeSelf);
    }
}
