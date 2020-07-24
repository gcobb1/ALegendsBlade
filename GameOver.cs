using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    //static public string Username;
    static public int Rounder = 10;
    static public int Killser = 10;
    static public bool LegendQuery = false;
    static public bool GameOverQuery = false;
    static public float MouseSens;
    static public bool MouseSet = false;
    static public float MotionBlur;
    static public bool MotionSet = false;


    public void GameOverMan(int Round, int Kills, bool LegendQ, bool GameOverQQ) {
        Rounder = Round;
        Killser = Kills;
        LegendQuery = LegendQ;
        GameOverQuery = GameOverQQ;
        Cursor.lockState = CursorLockMode.Confined;
    }
}

