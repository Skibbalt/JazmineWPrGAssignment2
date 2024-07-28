using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    public InventoryManager inventoryManager;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        ItemPickup itemPickup = other.GetComponent<ItemPickup>();
        if (itemPickup != null)
        {
            inventoryManager.Add(itemPickup.item);
            Destroy(other.gameObject);
        }
    }
}
