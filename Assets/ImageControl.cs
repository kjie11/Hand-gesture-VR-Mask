using System;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class ImageControl : MonoBehaviour
{
    
  
    public bool isLeftHand=false; 
     public event Action notifyLeftHand;
     public event Action notifyRightHand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public void Notify()
    {
        if (isLeftHand)
        {
             notifyLeftHand?.Invoke();
        }
        else
        {
            notifyRightHand?.Invoke();
        }
       
    }
}
