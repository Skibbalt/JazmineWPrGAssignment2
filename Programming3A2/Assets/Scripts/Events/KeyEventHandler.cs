using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class KeyEventHandler : MonoBehaviour
{
    public InventoryManager inventoryManager;

    public UnityEvent KeyEvent;

    void Start()
    {
        inventoryManager.OnKeyAdded += HandleKeyAdded;
    }

    void OnDestroy()
    {  
        inventoryManager.OnKeyAdded -= HandleKeyAdded;
    }

    
    void HandleKeyAdded(KeyClass key)
    {
      KeyEvent.Invoke();
    }
}
