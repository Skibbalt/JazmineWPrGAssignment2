using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Key")]

public class KeyClass : ItemClass
{
    [Header("Key")]
    //Key specific data
    public string keyName;

    public override ItemClass GetItem() { return this; }
    public override KeyClass GetKey() { return this; }
}
