using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Food")]


public class FoodClass : ItemClass
{
    [Header("Food")]
    //Key specific data
    public string foodName;

    public override ItemClass GetItem() { return this; }
    public override KeyClass GetKey() { return null; }
    public override FoodClass GetFood() { return this; }
}
