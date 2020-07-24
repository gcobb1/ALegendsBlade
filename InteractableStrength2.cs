using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//See Interactable Strength1 for comments
public class InteractableStrength2 : Interactable

{

    void Start()
    {
        Price = 6000;
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
            Debug.Log("Score Decrease 6000");
            PScript.DecreaseScore(Price);
            CScript.Strength += 125;
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
            PScript.OnSword = PScript.BladeofDarkness;
            PScript.OnSwordBackHand = PScript.BladeofDarkness;
            PScript.BladeofDarkness.SetActive(true);
            PScript.BladeofDarknessBH.SetActive(true);
            PScript.DarknessAud.Play();
            BoughtCounter++;
            Price = (int)((Price / 2) + Price);
        }
    }
    public override void Interactability()
    {
        Distancer = Vector3.Distance(posTrans, Player1.transform.position);
        if (Distancer < 3)
        {
            PScript.Counter4 = 1;
            PScript.HelperScreen.gameObject.SetActive(true);
            PScript.HelperScreen.text = ("Press E: Blade Of Darkness\n Cost " + Price.ToString());
        }
        else
        {
            PScript.Counter4 = 0;
            if ((PScript.Counter1 == 0) && (PScript.Counter2 == 0) && (PScript.Counter3 == 0) && (PScript.Counter5 == 0) && (PScript.Counter6 == 0))
            {
                PScript.HelperScreen.gameObject.SetActive(false);
            }
        }

    }
}
