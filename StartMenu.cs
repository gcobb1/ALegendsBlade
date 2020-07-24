using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartMenu : MonoBehaviour
{
    public HighScores HighS;
    //public UsernameScript UsernameSc;
    public Text RoundText;
    public Text KillsText;
    public Text LegendText;
    public GameObject submitHelper;
    public GameObject GameOverScener;
    public GameObject UIScener;
    public GameObject leaderScener;
    public GameObject OptionScener;
    public TMP_InputField inputField;
    string kills;
    string round;
    string legend;
    //public float canDestroy = 2f;
    //public bool Chekced;
    [System.Obsolete]
    void Start()
    {
        kills = GameOver.Killser.ToString();
        round = GameOver.Rounder.ToString();
        if (GameOver.LegendQuery == false)
        {
            legend = "Undetermined";
        }
        else
        {
            legend = "Confirmed";
        }
        RoundText.text = round;
        KillsText.text = kills;
        LegendText.text = legend;

        if (GameOver.GameOverQuery == true)
        {
            HighS.AddNewHighscore(UsernameScript.Username, GameOver.Rounder);
            GameOverScener.SetActive(true);
            UIScener.SetActive(false);
            leaderScener.SetActive(false);
            OptionScener.SetActive(false);
            inputField.text = UsernameScript.Username;
        }
        else
        {

            GameOverScener.SetActive(false);
            UIScener.SetActive(true);
            leaderScener.SetActive(false);
            OptionScener.SetActive(false);

        }
    }

    public void PlayGame()
    {
        if (UsernameScript.HasSubmitted == true)
        {
            //submitHelper.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            submitHelper.SetActive(true);
        }
    }
    public void ExitGameOverScreen()//also exits leaderboard
    {
        GameOverScener.SetActive(false);
        UIScener.SetActive(true);
        leaderScener.SetActive(false);
        OptionScener.SetActive(false);
    }
    public void EnterLeaderBoardScreen()
    {
        HighS.DownloadHighscores();
        GameOverScener.SetActive(false);
        UIScener.SetActive(false);
        leaderScener.SetActive(true);
        OptionScener.SetActive(false);
    }
    public void EnterOptionsScreen()
    {
        GameOverScener.SetActive(false);
        UIScener.SetActive(false);
        leaderScener.SetActive(false);
        OptionScener.SetActive(true);

    }
    public void QuitApp()
    {
        Application.Quit();
    }

}
