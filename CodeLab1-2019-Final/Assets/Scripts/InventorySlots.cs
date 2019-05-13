using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InventorySlots : MonoBehaviour, IDropHandler
{
    public int slotID;
    private InventoryManager _invent;

    // Start is called before the first frame update
    void Start()
    {
        _invent = GameObject.Find("ItemData").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Itemdata droppedItem = eventData.pointerDrag.GetComponent<Itemdata>();
        if (_invent.items[slotID].ID == -1)
        {
            _invent.items[droppedItem.slotIndex] = new Item();
            droppedItem.slotIndex = slotID;
            _invent.items[slotID] = droppedItem.item;
            
        }
    }
}
