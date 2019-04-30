using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is for restarting the game and end the game
public class GameManager : MonoBehaviour {

    private bool gameEnded = false;

    public DeathMenu deathMenu;

	// Update is called once per frame
	void Update () {

        if (gameEnded)
        {
            return;
        }

		if(AllManager.Lives <= 0)
        {
            EndGame();
        }
	}

    public void EndGame()
    {
        gameEnded = true;
        deathMenu.DeathMenuIsOn();
    }
}
