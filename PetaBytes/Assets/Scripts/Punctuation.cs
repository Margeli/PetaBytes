using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Punctuation : MonoBehaviour {
    public int points = 0;
    public int preys = 0;
    public int round = 0;
    public bool detected = false;
    public bool reset = false;
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
        // Win Condition
		if (preys == 0)
        {
            round++;
            roundText.text = "ROUND " + round;
            timer = 3.0f;

            if (round == 1)
            {
                // Crate new round
                preys = 2;
            }
        }

        // Lose Condition
        if (detected && !reset)
        {
            roundText.text = "GAME OVER";
            timer = 5.0f;
            reset = true;
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

            if (reset)
                SceneManager.LoadScene("mainScene");
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("mainScene");
    }
}
