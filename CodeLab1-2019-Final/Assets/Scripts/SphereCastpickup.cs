﻿using System.Collections;
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

    public Inventory inv;
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
                if (c.gameObject.name == "JadeEye")
                {
                    if (GameObject.Find("Item: Golden Key")) //你拿到钥匙了吗（前置要求的写法）
                    {
                        pickupitem1 = true;
                        Destroy(c.gameObject,2);
                        inv.AddItem(1);
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
