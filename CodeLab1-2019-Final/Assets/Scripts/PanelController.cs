using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public float Alpha1;

    public bool Interactable;
    public bool BlockRaycasts { get; set; }
    
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
                Openpanel();
            }
            else
            {
                Closepanel();
            }
        } 
    }

    //是否能点击图标打开呢
    public void ClickIcon()
    {
        if (GetComponent<CanvasGroup>().alpha == 0)
        {
            Openpanel();
        }
        else
        {
            Closepanel();
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
