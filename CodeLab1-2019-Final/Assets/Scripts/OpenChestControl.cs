using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChestControl : MonoBehaviour
{
    private List<Object> ChestToOpen;

    private Animator ChestAnimator;

    public SphereCastpickup unlock;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ChestAnimator = GetComponent<Animator>();
        unlock = GameObject.Find("ThirdPersonController").GetComponent<SphereCastpickup>();;
    }

    void Update()
    {
        if (unlock.pickupitem1 == false)
        {
            ChestAnimator.enabled = false;
            //ChestAnimator.speed = 0.0f;
        }
        else
        {
            //OpenChestEvent();
            //ChestAnimator.speed = 1.0f;
            ChestAnimator.enabled = true;
            ChestAnimator.Play("OpenState");
        }
        
    }

    
}
