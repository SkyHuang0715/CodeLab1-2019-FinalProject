using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//用以储存所有Item的信息
public class Itemdata : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Item item;
    public int slotIndex;

    InventoryManager _invent;
    

    // Start is called before the first frame update
    void Start()
    {
        _invent = GameObject.Find("ItemData").GetComponent<InventoryManager>();
    }

   

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            //this.transform.parent.transform.SetAsLastSibling();
            this.transform.SetParent(transform.parent.parent);
            this.transform.position = eventData.position;

            //在拖动时关闭raycast使鼠标位置可以被识别
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            
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
        
        //记得在每一次松开鼠标时打开raycast使物品能再次被拖动
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        
        //注意：要使用这个功能需要在item prefab上添加canvasGroup
    }
    
    
    
    
    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
        //鼠标右键使用物品 
      if (eventData.button == PointerEventData.InputButton.Right)
     {
        Debug.Log("right click this item");
        Destroy(gameObject);
     }
    }
}

