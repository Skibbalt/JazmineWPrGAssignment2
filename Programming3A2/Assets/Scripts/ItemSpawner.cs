using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [System.Serializable]
    public class ItemSpawnInfo
    {
        public ItemClass item;
        public Vector3 spawnPosition;
        public Quaternion spawnRotation = Quaternion.identity;
    }

    public List<ItemSpawnInfo> itemsToSpawn = new List<ItemSpawnInfo>();

    void Start()
    {
        SpawnItems();
    }

    void SpawnItems()
    {
        foreach (var itemInfo in itemsToSpawn)
        {
            if (itemInfo.item != null && itemInfo.item.itemPrefab != null)
            {
                GameObject spawnedItem = Instantiate(itemInfo.item.itemPrefab, itemInfo.spawnPosition, itemInfo.spawnRotation);
                ItemPickup itemPickup = spawnedItem.AddComponent<ItemPickup>();
                itemPickup.item = itemInfo.item;
            }
        }
    }
}
