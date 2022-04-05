using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InputWindow : MonoBehaviour
{
    public GameObject popup;
    public string doorCode = "8652";
    public InputField inputField;
    string userCode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkCode(string s)
    {
        userCode = s;
        if(userCode == "8652"){
            Debug.Log(userCode);
            doExitGame();
            popup.SetActive(true);
        }
        
    }

    void doExitGame(){
        Application.Quit();
        Debug.Log("You Win!");
    }
}
