using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    const string privateCode = "uNkaz8kgFUSq8kUyQgcprgtq4pO7KpvU-Ft3ccO6rSyw";
    const string publicCode = "5f1358beeb36cd09c447757c";
    const string webURL = "http://dreamlo.com/lb/";
    //public Highscore[] highscoresList;
    public Text Player1Name;
    public Text Player1Round;
    public Text Player2Name;
    public Text Player2Round;
    public Text Player3Name;
    public Text Player3Round;
    public Text Player4Name;
    public Text Player4Round;
    public Text Player5Name;
    public Text Player5Round;
    //public Text[] textList;


    //[System.Obsolete]
    //void Awake()
    //{
        //AddNewHighscore("Sebastian", 1);
        //AddNewHighscore("Fred", 3);
        //AddNewHighscore("Theresa", 2);
        //AddNewHighscore("Bernard", 2);
        //AddNewHighscore("Travis", 5);

        //DownloadHighscores(); //Use this when leaderboard is opened


   // }
    //void Start()
    //{
        //DownloadHighscores(); //Use this when leaderboard is opened
    //}
    [System.Obsolete]
    public void AddNewHighscore(string username, int score)
    {
        StartCoroutine(UploadNewHighscore(username, score));
    }
    [System.Obsolete]
    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
            print("Upload Successful");
        else
        {
            print("Error uploading: " + www.error);
        }
    }
    public void DownloadHighscores()
    {
        StartCoroutine("DownloadHighScoresFromDatabase");
    }
    [System.Obsolete]
    IEnumerator DownloadHighScoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
            FormatHighScores(www.text);
        else
        {
            print("Error Downloading: " + www.error);
        }
    }

    void FormatHighScores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        //highscoresList = new Highscore[entries.Length];
        //highscoresList = new Highscore[5];

        for (int i = 0; i < 5; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            //highscoresList[i] = new Highscore(username, score);
            switch (i % 5)
            {
                case 0:
                    Player1Name.text = username;
                    Player1Round.text = score.ToString();
                    break;
                case 1:
                    Player2Name.text = username;
                    Player2Round.text = score.ToString();
                    break;
                case 2:
                    Player3Name.text = username;
                    Player3Round.text = score.ToString();
                    break;
                case 3:
                    Player4Name.text = username;
                    Player4Round.text = score.ToString();
                    break;
                case 4:
                    Player5Name.text = username;
                    Player5Round.text = score.ToString();
                    break;
                default:
                    //Console.WriteLine("Default case");
                    break;
            }

            //print(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }
   /* public struct Highscore
    {
        public string username;
        public int score;
        public Highscore(string _userName, int _score)
        {
            username = _userName;
            score = _score;
        }
    }
   */
}

