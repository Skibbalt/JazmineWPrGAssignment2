using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ItemClass : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public GameObject itemPrefab;
    public Material itemMaterial;

    public abstract ItemClass GetItem();
    public abstract KeyClass GetKey();
}
