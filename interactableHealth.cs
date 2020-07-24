using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHealth : Interactable

{
   
    void Start()
    {
        Price = 750;
        posTrans = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        //posTrans = PScript.Transform;
    }
    void FixedUpdate()
    {
        Interactability();
    }
    // Start is called before the first frame update
    public override void Interact()
    {
        if (PScript.Score >= Price)
        {
            PScript.DecreaseScore(Price);
            PScript.HealthInv++;
            BoughtCounter++;
            Price = (int)((Price / 2) + Price);
            PScript.HealthIText.text = PScript.HealthInv.ToString();
        }
    }
    public override void Interactability()
    {
        Distancer = Vector3.Distance(posTrans, Player1.transform.position);
        if (Distancer < 3)
        {
            PScript.Counter2 = 1;
            PScript.HelperScreen.gameObject.SetActive(true);
            PScript.HelperScreen.text = ("Press E: Health Kit\n Cost " + Price.ToString());
        }
        else
        {
            PScript.Counter2 = 0;
            if ((PScript.Counter1 == 0) && (PScript.Counter3 == 0) && (PScript.Counter4 == 0) && (PScript.Counter5 == 0) && (PScript.Counter6 == 0))
            {
                PScript.HelperScreen.gameObject.SetActive(false);
            }
        }
    }
}
