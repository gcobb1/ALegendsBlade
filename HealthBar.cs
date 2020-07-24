using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    public Slider slider;    
    public Gradient gradient;
    public Image fill;
	//Health Bar UI
	//Sets max for slider
    public void SetMaxHealth(int Health)
    {
        slider.maxValue = Health;
        slider.value = Health;
        fill.color = gradient.Evaluate(1f);
  

    }
	//Sets current for slider
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    
    
}

