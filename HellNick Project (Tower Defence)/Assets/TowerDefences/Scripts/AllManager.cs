using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AllManager : MonoBehaviour
{
    public static int Money;
    public int startingMoney = 100;

    public static int Lives;
    public int startingLives = 3;

    public Text moneyText;
    public Text livesText;

    public DeathMenu deathMenu;

	// Use this for initialization
	void Start ()
    {
        Money = startingMoney;
        Lives = startingLives;
	}

    void Update()
    {
        moneyText.text = "$ " + Money.ToString();
        livesText.text = Lives.ToString() + " LIVES";

        if (deathMenu.isActiveAndEnabled)
        {
            gameObject.SetActive(false);
        }
    }
}
