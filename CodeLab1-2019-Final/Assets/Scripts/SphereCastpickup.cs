using System.Collections;
using System.Collections.Generic;
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
                    if (GameObject.Find("Item: Golden Key") && GameObject.Find("Item: Jade Eye")==null) //你拿到钥匙了吗（前置要求的写法）
                    {
                        pickupitem1 = true;
                        //Destroy(c.gameObject,2);
                        inv.AddItem(1);
                        
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
                
                //objToMove.Add(c.transform);
            }
        }

       // foreach (Transform t in objToMove)
        {
            //t.position += transform.position - lastPosition;
            
        }//Position = transform.position;
        
    }
}
