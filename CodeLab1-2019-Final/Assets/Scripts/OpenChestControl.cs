using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChestControl : MonoBehaviour
{
    private List<Object> ChestToOpen;

    public Animator ChestAnimator;

    public bool playanim;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ChestAnimator = GetComponent<Animator>();
        playanim = false;
    }

    void Update()
    {
        if (playanim == !playanim)
        {
            ChestAnimator.speed = 0.0f;
        }
        else
        {
            //OpenChestEvent();
            ChestAnimator.speed = 1.0f;
            ChestAnimator.Play("OpenState", 0, 0f);
        }
        
    }

    
}
