using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public PlayerScript PlayerScr;
    public EnemyManager EnemyMan;
    public GameObject EnemyManObj;

    void Start()
    {
        PlayerScr.Round = 1;
        PlayerScr.RoundText.text = PlayerScr.Round.ToString();
        PlayerScr.killCounterThreshold = PlayerScr.killCounterThreshold + (5 * PlayerScr.Round);
    }

	//Gives score based on killed enemy    
    public void KilledEnemy()
    {
        PlayerScr.Kills++;
        PlayerScr.IncreaseScore(100);
        PlayerScr.ScoreText.text = PlayerScr.Score.ToString();
        CheckRound();
    }
	//When an enemy is killed, check the round threshold algorithm to see if the next round should display along with sounds and correlations
    public void CheckRound()
    {
        if ((PlayerScr.Kills % PlayerScr.killCounterThreshold) == 0)
        {

            PlayerScr.Round++;
            PlayerScr.ChangeRoundAud.Play();
            PlayerScr.RoundText.text = PlayerScr.Round.ToString();
            PlayerScr.killCounterThreshold = PlayerScr.killCounterThreshold + (5 * PlayerScr.Round);
            EnemyMan.SpawnNewEnemy();
            EnemyMan.SpawnNewEnemy();
            Debug.Log("Round Change");

        }

    }
}

