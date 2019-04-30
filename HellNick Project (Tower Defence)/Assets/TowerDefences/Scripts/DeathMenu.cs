using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

    public Image backgroundImage;

    public float animationTransition = 3.0f;

    // Update is called once per frame
    void Update ()
    {
        animationTransition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.yellow, animationTransition);
	}

    public void DeathMenuIsOn()
    {
        gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu(string mainMenu)
    {
        SceneManager.LoadScene(mainMenu);
    }
}
