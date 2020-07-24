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
            //GameOver.MouseSens = 
        }
        else
        {
            GameOver.MouseSens = 100f;
        }
        if (GameOver.MotionSet == true)
        {
            sliderMotion.value = GameOver.MotionBlur;
            //GameOver.MouseSens = 
        }
        else
        {
            GameOver.MotionBlur = 74f;
        }

    }
    public void SetMouse(float mouseSenser)
    {
        GameOver.MouseSet = true;
        GameOver.MouseSens = mouseSenser;
    }
    public void SetMotion(float motionSenser)
    {
        GameOver.MotionSet = true;
        GameOver.MotionBlur = motionSenser;
    }
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

