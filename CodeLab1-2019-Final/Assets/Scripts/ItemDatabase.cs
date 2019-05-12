using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class ItemDatabase : MonoBehaviour
{
    private JsonData itemdata;
    private List<Item> database = new List<Item>();

    // Start is called before the first frame update
    void Awake()
    {
        itemdata = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/ItemAssets/items.json"));
        ConstructItemDatabase();
        Debug.Log(database[0].Descrip);
        Debug.Log(FetchItemByID(1).Title +": "+ FetchItemByID(1).Descrip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemdata.Count; i++)
        {
            database.Add(new Item ((int) itemdata[i]["id"],
                                   itemdata[i]["title"].ToString(), 
                                   (int)itemdata[i]["value"],
                                   itemdata[i]["description"].ToString(),
                                   itemdata[i]["madeby"].ToString(),
                                   itemdata[i]["slug"].ToString()));
        }
    }//loaded every lines from the json file
    
    //通过ID查找物品信息
    public Item FetchItemByID(int _id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (_id == database[i].ID)
            {
                return database[i];
            }
        }

        return null;
    }
    
}

//创建Item
public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public string Descrip { get; set; }
    public string Madeby { get; set; }
    
    public Sprite Sprite { get; set; }

    public Item(int _id, string _title, int _value, string _des, string _mader,string _slug)
    {
        this.ID = _id;
        this.Title = _title;
        this.Value = _value;
        this.Descrip = _des;
        this.Madeby = _mader;
        this.Sprite = Resources.Load<Sprite>("Items/"+_slug); //链接到图片
        
        Debug.Log(Resources.Load<Sprite>("Items/"+_slug));
    }

    public Item()
    {
        this.ID = -1;

    }
}
