using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public ItemClass itemAdded;
    public ItemClass itemRemoved;

    public List<ItemClass> items = new List<ItemClass>();

    public void Start()
    {
        Add(itemAdded);
    }

    public void Add(ItemClass item)
    {
        items.Add(item);
    }

    public void Remove (ItemClass item)
    {
        items.Remove(item);
    }

}
