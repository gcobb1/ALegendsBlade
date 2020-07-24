using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    
    public PlayerScript PlayerScript;

    	//Pause at tab and unpause if tabbed already
	void Update()
    	{
        if (Input.GetKeyDown(KeyCode.Tab))
         {
            if (PlayerScript.GameOverQ == false)
            {
                if (GameIsPaused)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Resume();
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Confined;
                    Pause();
                }
            }
        }
    }
   //Reveal Ui on Pause and disable on resume. Resume functionality 
    public void Resume()
    {
        //pauseMenuUI.SetActive(false);
        PlayerScript.ControlsText.text = "Controls";
        PlayerScript.ControlsText.fontSize = 65;
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
    }
    void Pause()
    {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
    }
	//Go to Main Menu
    public void QuitGamer()
    {
        
        Time.timeScale = 1f;
        GameIsPaused = false;
        PlayerScript.GameOver();
        pauseMenuUI.SetActive(false);
    }

	//Show interactive control text
    public void ControlsMove()
    {
        PlayerScript.ControlsText.fontSize = 10;
        PlayerScript.ControlsText.text = "Attack   Left Mouse\nMovement WASD\nRun LeftShift\nJump SpaceBar\nSneak Walk     C\nInteract     e\nShieldHeal   R\nHealthHeal   F";
    }
}

