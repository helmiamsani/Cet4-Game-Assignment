using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject mainmenu, options; // Variable for menu and options

    // Load another scene
    public void LoadScene(int NewScene)
    {
        // Getting a scene from scene manager
        SceneManager.LoadScene(NewScene);
    }

    // Exiting the game
    public void Exit()
    {
        // Quiting the game
        Application.Quit();
    }

    // Creating toggle that will be used for option menu
    public void ToggleOptions(bool toggle)
    {
        // If one of the panel is on (in this case main menu panel is on)
        if (toggle)
        {
            // main menu panel is set off, since the gameplay is on main menu panel
            mainmenu.SetActive(false);
            // option panel is set to true because the option button in main menu will forward player into option panel
            options.SetActive(true);
        }
        // Once player inside option menu
        else
        {
            // Option panel is set to false because there is no need to go back to option panel
            options.SetActive(false);
            // main menu panel is set to true because it needs to go back to main menu panel
            mainmenu.SetActive(true);
        }
    }
}
