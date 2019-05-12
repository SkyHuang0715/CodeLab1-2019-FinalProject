using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour
{
    public float Alpha1;
    public bool Interactable;
    public bool BlocksRaycasts { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //设定初始状态
        Closepanel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (GetComponent<CanvasGroup>().alpha == 0)
            {
              //  Debug.Log("Open the bag!");
                Openpanel();
            }
            else 
            {
               // Debug.Log("Close the bag!");
                Closepanel();
            }
        }
    }

    void Openpanel()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().interactable = true;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void Closepanel()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }


}
