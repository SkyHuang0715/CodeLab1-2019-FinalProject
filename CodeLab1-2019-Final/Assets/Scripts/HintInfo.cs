using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintInfo : MonoBehaviour
{
   
    public GameObject myText; // Assign the text to this in the inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Hintshow());
        }

       
    }
    
    IEnumerator Hintshow() {
        myText.SetActive(true); // Enable the text so it shows
        yield return new WaitForSeconds (5);
        myText.SetActive( false ); // Disable the text so it is hidden
    }
    
}
