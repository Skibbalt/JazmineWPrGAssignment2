using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    
    public GameObject panel;

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.I))
        {
          
            panel.SetActive(!panel.activeSelf);
        }
    }
}
