using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class ButtonHandler : MonoBehaviour
{   
    public TMP_InputField p1Name;
    public TMP_InputField p2Name;
    public TMP_InputField pHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVariables()
    {
        VariableHandler.vPasser.playerName1 = p1Name.text;
        VariableHandler.vPasser.playerName2 = p2Name.text;
        VariableHandler.vPasser.playerHealth = System.Convert.ToInt32(pHealth.text);
        SceneManager.LoadScene(2);
    }
}
