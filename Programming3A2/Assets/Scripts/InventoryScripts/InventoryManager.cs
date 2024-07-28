using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class InventoryManager : MonoBehaviour
{
    public GameObject slotsHolder;
    public ItemClass itemAdded;
    public ItemClass itemRemoved;
    public Image equippedImage;
    public TextMeshProUGUI equippedItemText;

    public UnityEvent KeyEvent;

    public List<ItemClass> items = new List<ItemClass>();

    private GameObject[] slots;

  
    public ItemClass CurrentlyEquippedItem { get; private set; }

    
    public delegate void KeyAddedHandler(KeyClass key);
    public event KeyAddedHandler OnKeyAdded;

    public void Start()
    {
        slots = new GameObject[slotsHolder.transform.childCount];
        for (int i = 0; i < slotsHolder.transform.childCount; i++)
        {
            slots[i] = slotsHolder.transform.GetChild(i).gameObject;
           
            Button button = slots[i].GetComponent<Button>();
            if (button == null)
            {
                button = slots[i].AddComponent<Button>();
            }
            int index = i; 
            button.onClick.AddListener(() => OnSlotClicked(index));
        }

        RefreshUI();
        Add(itemAdded);
        Remove(itemRemoved);
    }

    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemIcon;
            }
            else
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

       
        if (item is KeyClass key)
        {
            OnKeyAdded?.Invoke(key);
            KeyEvent.Invoke();
        }
    }

    public void Remove(ItemClass item)
    {
        items.Remove(item);
        RefreshUI();
    }

    public void OnSlotClicked(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            UnityEngine.Debug.Log("Slot clicked: " + index + ", Item: " + items[index].itemName);
            EquipItem(items[index]);
        }
    }

    public void EquipItem(ItemClass item)
    {
        UnityEngine.Debug.Log("Equipping item: " + item.itemName);

        
        CurrentlyEquippedItem = item;

       
        if (equippedImage != null)
        {
            equippedImage.sprite = item.itemIcon;
            equippedImage.enabled = true;
            UnityEngine.Debug.Log("Equipped image updated: " + item.itemIcon.name);
        }

        if (equippedItemText != null)
        {
            equippedItemText.text = item.itemText;
            UnityEngine.Debug.Log("Equipped item text updated: " + item.itemText);
        }

        
        RefreshUI();
    }
}
