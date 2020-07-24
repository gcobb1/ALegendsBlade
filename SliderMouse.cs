using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMouse : MonoBehaviour
{
    
    public Slider sliderMouse;
    public Slider sliderMotion;
    public Toggle WindowToggle;
    
    // Start is called before the first frame update
    void Start()
    {
        if(GameOver.MouseSet == true)
        {
            sliderMouse.value = GameOver.MouseSens;
        }
        else
        {
            GameOver.MouseSens = 100f;
        }
        if (GameOver.MotionSet == true)
        {
            sliderMotion.value = GameOver.MotionBlur;
        }
        else
        {
            GameOver.MotionBlur = 74f;
        }

    }
	//Set mouse sens and change it by storing static variable
    public void SetMouse(float mouseSenser)
    {
        GameOver.MouseSet = true;
        GameOver.MouseSens = mouseSenser;
    }

	//Set motion Blur and change it by storing static variable
    public void SetMotion(float motionSenser)
    {
        GameOver.MotionSet = true;
        GameOver.MotionBlur = motionSenser;
    }

	//Set Window Mode and full
    public void ToggleChange(bool Windowmoder)
    {
        if (Windowmoder == true)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }
    }
}

