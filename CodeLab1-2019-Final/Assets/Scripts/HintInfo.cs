using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintInfo : MonoBehaviour
{
   
    public GameObject myText; // Assign the text to this in the inspector
    public Text hintString;

    public bool mes0;
    public bool mes1;
    public bool mes2;

    public void Start()
    {
        //mes0 = true;
       // mes1 = false;
       // mes2 = false;
    }
    
    public void HintMes()
    {
        //用string来包含不同的提示语  
        String mes = "";

            //myText.GetComponent<Text>().text = "You require a golden key to open the chest.";
     
            StartCoroutine(Hintshow());
        

        if (mes0 == true)
        {
            mes = "There is nothing here. Check other places.";
           
        }
        else if (mes1 == true) 

        {
            mes = "You require a golden key to open the chest.";
            
        }else if (mes2 == true)
        {
            mes = "You require all the three items to open JadeFox's treasure chest.";
        }
        
        hintString.text = mes;

    }
    
    IEnumerator Hintshow() {
        myText.SetActive(true); // Enable the text so it shows
        yield return new WaitForSeconds (5);
        myText.SetActive( false ); // Disable the text so it is hidden
    }
    
}
