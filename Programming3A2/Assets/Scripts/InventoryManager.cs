using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    public GameObject slotsHolder;
    public ItemClass itemAdded;
    public ItemClass itemRemoved;

    public List<ItemClass> items = new List<ItemClass>();

    private GameObject[] slots;

    public void Start()
    {
        slots = new GameObject[slotsHolder.transform.childCount];
        for (int i = 0;i < slotsHolder.transform.childCount;i++)
        {
            slots[i] = slotsHolder.transform.GetChild(i).gameObject;
        }

        RefreshUI();
        Add(itemAdded);
        Remove(itemRemoved);
    }

    public void RefreshUI()
    {
        for (int i =0; i < slots.Length;i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemIcon;
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }
    }

    public void Add(ItemClass item)
    {
        items.Add(item);
        RefreshUI();
    }

    public void Remove (ItemClass item)
    {
        items.Remove(item);
        RefreshUI();
    }
   
}
