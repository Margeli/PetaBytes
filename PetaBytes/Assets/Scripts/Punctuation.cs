using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Punctuation : MonoBehaviour {
    public int points = 0;
    public int preys = 0;
    public int round = 0;
    private Text pointsText;
    private Text roundText;
    private float timer = 0.0f;

	void Start () {
        pointsText = GameObject.Find("Points").GetComponent<Text>();
        roundText = GameObject.Find("Round").GetComponent<Text>();
        pointsText.enabled = true;
        roundText.enabled = false;
    }
	
	void Update () {
		if (preys == 0)
        {
            round++;
            timer = 3.0f;
            roundText.text = "ROUND " + round;

            if (round == 1)
            {
                // Crate new round
                preys++;
            }
        }

        ShowRound();
	}

    public void UpdatePoints(int pointsToAdd)
    {
        if (!pointsText)
            pointsText = GameObject.Find("Points").GetComponent<Text>();

        points += pointsToAdd;
        if (points < 0)
            points = 0;
        pointsText.text = "Points: " + points;
    }

    void ShowRound()
    {
        if (timer > 0.0f)
        {
            if (!roundText.enabled)
                roundText.enabled = true;
            timer -= Time.deltaTime;
        }
        else
        {
            if (roundText.enabled)
                roundText.enabled = false;
        }
    }
}
