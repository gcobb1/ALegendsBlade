using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//See HealthBar for similar comments
public class ShieldBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
	//Sliders are set depending on max or present value
    public void SetShield(int shield)
    {
        slider.value = shield;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void SetMaxShield(int shield)
    {
        slider.maxValue = shield;
        slider.value = shield;
        
        fill.color = gradient.Evaluate(1f);

    }
    
    
}

