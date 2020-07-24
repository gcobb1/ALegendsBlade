using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



//This Script simply validates the Chars for the Username to between 1-15 in length and only to carry alphanumerics!
public class UsernameScript : MonoBehaviour
{
    static public string Username;
    public TMP_InputField inputField;
    static public bool HasSubmitted = false;
    public GameObject submitHelper;
    string validCharacters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    // Start is called before the first frame update
    void Start()
    {
        inputField.onValidateInput = (string text, int charIndex, char addedChar) =>
        {
            return ValidateChar(validCharacters, addedChar);
        };
        inputField.characterLimit = 15;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Submit();
        }
    }
    // Update is called once per frame
    public void Submit()
    {
        
        if (inputField.text.Length != 0)
        {
            HasSubmitted = true;
            Username = inputField.text;
            submitHelper.SetActive(false);
        }
       
    }
    public char ValidateChar(string validCharacters, char addedChar)
    {
        if(validCharacters.IndexOf(addedChar) != -1)
        {
            return addedChar;
        }
        else
        {
            return '\0';
        }
    }

}
