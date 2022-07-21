using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using InputManager;

public class GameMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject keybindingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        //bool pause = Input.GetKeyDown(KeyCode.Escape);
        /*
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pauseMenu.activeSelf || optionsMenu.activeSelf || keybindingsMenu.activeSelf)
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                optionsMenu.SetActive(false);
                keybindingsMenu.SetActive(false);
                Cursor.visible = true;
            } else
            {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                optionsMenu.SetActive(false);
                keybindingsMenu.SetActive(false);
                Cursor.visible = false;
            }
        }
        */
    }

    public void quit()
    {
        Application.Quit();
    }

    public void resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
    }

    public void saveGame()
    {

    }
}
