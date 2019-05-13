using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//用以储存所有Item的信息
public class Itemdata : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler
{
    public Item item;
    public int slotIndex;

    InventoryManager _invent;

    // Start is called before the first frame update
    void Start()
    {
        _invent = GameObject.Find("ItemData").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            //this.transform.parent.transform.SetAsLastSibling();
            this.transform.SetParent(transform.parent.parent);
            this.transform.position = eventData.position;
        }
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            //this.transform.parent.transform.SetAsLastSibling();
            this.transform.position = eventData.position;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //move all the data after drag the item
        this.transform.SetParent(_invent.slots[slotIndex].transform);
        this.transform.position = this.transform.parent.position;
    }
}

