using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Please see InteractableHealth.cs for comments
public class InteractableShield : Interactable
    
{
    
    void Start()
    {
        Price = 1000;
        BoughtCounter = 0;
        posTrans = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        //posTrans = PScript.Transform;
    }
    void FixedUpdate()
    {
        Interactability();
    }



    public override void Interact()
    {
        if (PScript.Score >= Price)
        {
            //BoughtCounter++;
            //Price = (int)((Price * 1.5) + Price);
            PScript.DecreaseScore(Price);
            PScript.ShieldsInv++;
            BoughtCounter++;
            Price = (int)((Price / 2) + Price);
            PScript.ShieldIText.text = PScript.ShieldsInv.ToString();
        }
    }
    public override void Interactability()
    {
        Distancer = Vector3.Distance(posTrans, Player1.transform.position);
        if(Distancer < 3)
        {
            PScript.Counter1 = 1;
            PScript.HelperScreen.gameObject.SetActive(true);
            PScript.HelperScreen.text = ("Press E: Shield Orb\n Cost " + Price.ToString());
        }
        else
        {
            PScript.Counter1 = 0;
            if ((PScript.Counter2 == 0) && (PScript.Counter3 == 0) && (PScript.Counter4 == 0)&& (PScript.Counter5 == 0) && (PScript.Counter6 == 0))
            {
                PScript.HelperScreen.gameObject.SetActive(false);
            }
        }

    }
}

