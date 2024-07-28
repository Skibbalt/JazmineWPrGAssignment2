using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class DoorController : MonoBehaviour
{
    public InventoryManager inventoryManager; 
    public float doorOpenAngle = 90f; 
    public float doorOpenSpeed = 2f; 

    private bool isPlayerInTrigger = false; 
    private bool isDoorOpen = false;

    public UnityEvent DoorEvent;

    void Update()
    {
        
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
           
            if (inventoryManager.CurrentlyEquippedItem is KeyClass)
            {
                OpenDoor();
            }
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }

    void OpenDoor()
    {
        if (!isDoorOpen)
        {
            isDoorOpen = true;
            StartCoroutine(OpenDoorRoutine());
        }
    }

    IEnumerator OpenDoorRoutine()
    {
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles + Vector3.up * doorOpenAngle);
        float time = 0;

        while (time < 1)
        {
            time += Time.deltaTime * doorOpenSpeed;
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, time);
            yield return null;
            DoorEvent.Invoke();
        }

        transform.rotation = targetRotation;
    }
}
