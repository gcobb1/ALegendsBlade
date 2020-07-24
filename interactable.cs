using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public PlayerScript PScript;
    public ControllerScript CScript;
    public GameObject Player1;
    public float radius = 4f;
    public Vector3 posTrans;
    public float Distancer;
    public int Price;
    public float BoughtCounter = 0;


    void Start()
    {
        
        Player1 = GameObject.FindWithTag("Player");
        PScript = Player1.GetComponent<PlayerScript>();
        CScript = Player1.GetComponent<ControllerScript>();

    }
    public virtual void Interact()
    {
        Debug.Log("Interacted");
    }
    public virtual void Interactability()
    {
        Debug.Log("Interactable");
    }

}
