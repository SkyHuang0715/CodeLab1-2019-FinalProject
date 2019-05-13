using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public GameObject slot;
    public GameObject item;

    private ItemDatabase itemdatabase;

    public List<GameObject> slots = new List<GameObject>();
    public List<Item> items = new List<Item>();

    private GameObject slotPanel;
    // Start is called before the first frame update
    void Start()
    {
        itemdatabase = GetComponent<ItemDatabase>();
        slotPanel = GameObject.Find("ItemPanel");

        for (int i = 0; i < 16; i++)
        {
            slots.Add(Instantiate(slot, transform.parent));
            slots[i].transform.SetParent(slotPanel.transform,false);
            //不加false会根据世界坐标创建子物体，maximize和窗口生成不同size

            slots[i].GetComponent<InventorySlots>().slotID = i; 

            items.Add(new Item()); //add new item
            
        }
        
        //测试功能：添加一个物品到物品栏
        Additem(0);
        Additem(1);
        Additem(0);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Press E to pick up items
        if (Input.GetKeyDown(KeyCode.E)){
            Additem(0);
            Additem(1);
            Additem(0);
        
        }
    }

    public void Additem(int _id)
    {
        Item itemToAdd = itemdatabase.FetchItemByID(_id);

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(item);
                
                itemObj.transform.position = Vector2.zero;
                itemObj.transform.SetParent(slots[i].transform,false);
                itemObj.name = items[i].Title;
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;

                itemObj.GetComponent<Itemdata>().item = itemToAdd;
                itemObj.GetComponent<Itemdata>().slotIndex = i;

                break;
            }
        }
    }
}
