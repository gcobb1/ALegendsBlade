using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//See InteractableStrength1 for Comments
public class InteractableStrength3 : Interactable

{

    void Start()
    {
        Price = 12000;
        posTrans = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
    void FixedUpdate()
    {
        Interactability();
    }
    public override void Interact()
    {
        if (PScript.Score >= Price)
        {
            Debug.Log("Score Decrease 12000");
            PScript.DecreaseScore(Price);
            CScript.Strength += 312;
            CScript.StrengthNumber.text = CScript.Strength.ToString();
            if (CScript.NewSpeed < 10)
            {
                CScript.NewSpeed += 1f;
            }
            if (CScript.RunSpeed < 17)
            {
                CScript.RunSpeed += 1f;
                CScript.SpeedNumber.text = CScript.RunSpeed.ToString();
            }
            if (PScript.OnSword == PScript.BladeofLight)
            {
                PScript.BladeofLight.SetActive(false);
            }
            else if (PScript.OnSword == PScript.BladeofLightning)
            {
                PScript.BladeofLightning.SetActive(false);
                PScript.BladeofLightningBH.SetActive(false);
            }
            else if (PScript.OnSword == PScript.BladeofDarkness)
            {
                PScript.BladeofDarkness.SetActive(false);
                PScript.BladeofDarknessBH.SetActive(false);
            }
            else if (PScript.OnSword == PScript.BladeofTheSun)
            {
                PScript.BladeofTheSun.SetActive(false);
                PScript.BladeofTheSunBH.SetActive(false);
            }
            else if (PScript.OnSword == PScript.ALegendsBlade)
            {
                PScript.ALegendsBlade.SetActive(false);
                PScript.ALegendsBladeBH.SetActive(false);
            }
            PScript.OnSword = PScript.BladeofTheSun;
            PScript.OnSwordBackHand = PScript.BladeofTheSun;
            PScript.BladeofTheSun.SetActive(true);
            PScript.BladeofTheSunBH.SetActive(true);
            PScript.SunAud.Play();
            BoughtCounter++;
            Price = (int)((Price / 2) + Price);
        }
    }
    public override void Interactability()
    {
        Distancer = Vector3.Distance(posTrans, Player1.transform.position);
        if (Distancer < 3)
        {
            PScript.Counter5 = 1;
            PScript.HelperScreen.gameObject.SetActive(true);
            PScript.HelperScreen.text = ("Press E: Blade Of The Sun\n Cost " + Price.ToString());
        }
        else
        {
            PScript.Counter5 = 0;
            if ((PScript.Counter1 == 0) && (PScript.Counter2 == 0) && (PScript.Counter3 == 0) && (PScript.Counter4 == 0) && (PScript.Counter6 == 0))
            {
                PScript.HelperScreen.gameObject.SetActive(false);
            }
        }

    }
}

