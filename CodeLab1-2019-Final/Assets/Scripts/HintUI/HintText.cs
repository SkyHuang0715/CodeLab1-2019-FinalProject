using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;

public class HintText : MonoBehaviour
{
    public static GameObject UItext; //公共静态变量，可用于其他脚本

    public Text hintString; //用string设置不同的hint

   
    [SerializeField] private float hintTimer;
    private float delayTime;
    private bool canCount = true;
    private bool doOnce = false;

    public GameObject newHint;
    // Start is called before the first frame update
    void Start()
    {
     UItext = GameObject.Find("hintText");
     UItext.SetActive(false); //保持隐藏

     hintTimer = delayTime;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {

            if (delayTime > 0.0f && true)
            {
                delayTime -= Time.deltaTime;
                UItext.SetActive(true);

                String mes = "";
                hintString.text = mes;

                mes = "You picked up the golden key";

            }else if (delayTime <= 0.0f )
            {
                UItext.SetActive(false);
                hintTimer = delayTime;
            }
        }

        
    }

   
   
    

}
