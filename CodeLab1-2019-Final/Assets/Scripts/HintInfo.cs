using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintInfo : MonoBehaviour
{
   
    public GameObject myText; // Assign the text to this in the inspector
    /* //好了事实证明string并不适合有太复杂condition的情况
     //在这里浪费了很长时间，所以保留了这一段，引以为戒
  public Text hintString;

   public bool mes0;
   public bool mes1;
   public bool mes2;
   public bool mes3;

   public bool findsomething;
   public bool nothinghere;
   public bool nokeyinbag;
   public bool needthreeitems;


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
       }
       else if (mes2 == true)
       {
           mes = "You require all the three items to open JadeFox's treasure chest.";
       }
       else if (mes3 == true)
       {
           mes = "You got a new item!";
       }
       hintString.text = mes;

   }*/
    
    //来区分不同情况，以此避免提示的错误显示
    //1. 找到物品的情况
    public void HintMes0()
    {
        StartCoroutine(Hintshow());
        myText.GetComponent<Text>().text = "You got a new item!" ; 
    }
    
    //2. 什么也没有的情况
    public void HintMes1()
        {
            StartCoroutine(Hintshow()); 
          myText.GetComponent<Text>().text = "There is nothing here. Check other places." ; 
        }
    
    //3. 找到箱子但没有钥匙的情况
    public void HintMes2()
    {
        StartCoroutine(Hintshow());
        myText.GetComponent<Text>().text = "You require a golden key to open the chest." ; 
    }
    //4. 东西没找全的情况
    public void HintMes3()
    {
        StartCoroutine(Hintshow());
        myText.GetComponent<Text>().text = "You require all the three items to open JadeFox's treasure chest." ; 
    }
    
    IEnumerator Hintshow() {
        myText.SetActive(true); // Enable the text so it shows
        yield return new WaitForSeconds (5);
        myText.SetActive( false ); // Disable the text so it is hidden
    }
    
}
