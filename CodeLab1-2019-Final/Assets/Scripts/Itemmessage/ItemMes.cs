using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class ItemMes : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject itemmes;
    private bool _isEnter;
    private float _timer;

    void Start()
    {
        //itemmes.transform.SetAsLastSibling (); //Since it is rendered the latest, it is displayed on the top.
    }

    void Update()
    {

        _timer += Time.deltaTime;


        if (_isEnter && _timer - 1.0f > 0f)
        {
            itemmes.SetActive(true);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _timer = 0;
        _isEnter = true;
        itemmes.transform.SetParent(transform.parent.parent,false); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isEnter = false;
        itemmes.SetActive(false);
        itemmes.transform.SetParent(this.transform,false);
    }
}