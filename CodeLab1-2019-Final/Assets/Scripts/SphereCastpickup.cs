using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SphereCastpickup : MonoBehaviour
{
    

    private Transform pickedUpObject;

    //private Vector3 lastPosition;

    //private List<Transform> objToMove = new List<Transform>();
    

    public LayerMask mask;
    
    
    //关于捡起物品是否发生
    public bool pickupitem0;
    public bool pickupitem1;
    public bool pickupitem2;
    public bool pickupitem3;

    public Inventory inv;

    public OpenChestControl opened;

    //因为要多次用到，给他们每人一个title吧
    private GameObject findkey;
    private GameObject findjade;
    private GameObject findsword;
    private GameObject findring;
    
    // Start is called before the first frame update
    void Start()
    {
        pickupitem0 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            Collider[] pickobjs;
            pickobjs = Physics.OverlapSphere(transform.position + Vector3.up, 2.0f, mask);
            
            inv = GameObject.Find("Inventory").GetComponent<Inventory>();
            opened = GameObject.Find("JadeEyeChest").GetComponent<OpenChestControl>();

            //定义一下每人的title
            findkey = GameObject.Find("Item: Golden Key");
            findjade = GameObject.Find("Item: Jade Eye");
            findsword = GameObject.Find("Item: The Legend Sword");
            findring = GameObject.Find("Item: Red Gem Ring");
            
            //定义一下提示文字
            
            //objToMove = new List<Transform>();
            foreach (Collider c in pickobjs)
            {
                //检测是否碰到钥匙
                if (c.gameObject.name == "Cube")
                {
                    pickupitem0 = true;
                    Destroy(c.gameObject,2);
                    inv.AddItem(0);
                }
                
                //检测是否开箱拿到玉眼
                if (c.gameObject.name == "JadeEyeChest")
                {
                    if (findkey && GameObject.Find("Item: Jade Eye")==null) //你拿到钥匙了吗（前置要求的写法）
                    {
                        pickupitem1 = true;
                        //Destroy(c.gameObject,2);
                        inv.AddItem(1);
                        
                    }
                    //如果没有钥匙
                    else
                    {
                        
                    }
                    
                }
                
                //检测青云剑
                if (c.gameObject.name == "LegendSword")
                {
                    pickupitem2 = true;
                    Destroy(c.gameObject,2);
                    inv.AddItem(2);
                }
               
                //检测宝石戒指
                if (c.gameObject.name == "gemRing")
                {
                    pickupitem3 = true;
                    Destroy(c.gameObject,2);
                    inv.AddItem(3);
                }
                
                //最终的宝藏
                if (c.gameObject.name == "TreasureChest")
                {
                    if (findjade && findring && findsword) //你拿到所有三样物品了吗（前置要求的写法）
                    {
                        pickupitem0 = true;
                        //Destroy(c.gameObject,2);
                        inv.AddItem(0);
                        
                    }
                    
                }
                //objToMove.Add(c.transform);
            }
        }

       // foreach (Transform t in objToMove)
        {
            //t.position += transform.position - lastPosition;
            
        }//Position = transform.position;
        
    }
}
