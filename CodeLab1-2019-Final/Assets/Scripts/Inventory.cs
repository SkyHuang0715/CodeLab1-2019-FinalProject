using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

	GameObject inventoryPanel;
	GameObject slotPanel;
	ItemDatabase database;
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	private int slotAmount;
	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();


	public SphereCastpickup spherepick;
	
	//只添加一次的写法尝试
	private bool done = false;
	private bool done1 = false;
	
	void Start()
	{
		database = GetComponent<ItemDatabase>();
		slotAmount = 16;
		inventoryPanel = GameObject.Find("InventoryPanel");
		slotPanel = inventoryPanel.transform.Find("SlotPanel").gameObject;
		for (int i = 0; i < slotAmount; i++)
		{
			items.Add(new Item());
			slots.Add(Instantiate(inventorySlot));
			slots[i].GetComponent<Slot>().id = i;
			slots[i].transform.SetParent(slotPanel.transform,false);
		}
/*
		AddItem(0);
		AddItem(1);
		AddItem(3);
		AddItem(0);
		AddItem(0);
		AddItem(0);
		AddItem(0);
		AddItem(1);
		AddItem(1);
		AddItem(2);*/
		spherepick = GameObject.Find("ThirdPersonController").GetComponent<SphereCastpickup>();
	}
	
	//具体要如何拾取物品，需要先找到spherecast脚本里pick了哪一样东西
	//然后根据物品编号来添加到物品栏
	void Update()
	{
		//捡到钥匙啦~
		/*if (spherepick.pickupitem0 == true && done == false) 
		{
			AddItem(0);
			done = true;
			
		}
		
		//拿到玉眼啦~
		if (spherepick.pickupitem1 == true && done1 == false) 
		{
			AddItem(1);
			done1 = true;
		}*/
	}
	
	
	public void AddItem(int id)
	{
		Item itemToAdd = database.FetchItemById(id);
		if (itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
		{
			for (int i = 0; i < items.Count; i++)
			{
				if (items[i].Id == id)
				{
					ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
					data.amount++;
					data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
					break;
				}
			}
		}
		else
		{
			for (int i = 0; i < items.Count; i++)
			{
				if (items[i].Id == -1)
				{
					items[i] = itemToAdd;
					GameObject itemObj = Instantiate(inventoryItem);
					itemObj.GetComponent<ItemData>().item = itemToAdd;
					itemObj.GetComponent<ItemData>().slotId = i;
					
					//这里两行的顺讯很重要，用于保证物品生成在框里
					itemObj.transform.position = Vector2.zero;
					itemObj.transform.SetParent(slots[i].transform, false);
					
					itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
					itemObj.name = "Item: " + itemToAdd.Title;
					//slots[i].name = "Slot: " + itemToAdd.Title;
					break;
				}
			}
		}
	}

	bool CheckIfItemIsInInventory(Item item)
	{
		for (int i = 0; i < items.Count; i++)
		{
			if (items[i].Id == item.Id)
			{
				return true;
			}
		}

		return false;
	}

}
