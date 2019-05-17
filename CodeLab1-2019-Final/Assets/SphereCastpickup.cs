using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCastpickup : MonoBehaviour
{
    

    private Transform pickedUpObject;

    //private Vector3 lastPosition;

    //private List<Transform> objToMove = new List<Transform>();
    

    public LayerMask mask;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            Collider[] pickobjs;
            pickobjs = Physics.OverlapSphere(transform.position + Vector3.up, 2.0f, mask);
            
            //objToMove = new List<Transform>();
            foreach (Collider c in pickobjs)
            {
                if (c.gameObject.name == "Cube")
                {
                    Destroy(c.gameObject,2);
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
